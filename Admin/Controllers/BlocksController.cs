using Data.IRepository;
using Data.Service;
using Domain.Models;
using Domain.Models.NotificationHandlerVM;
using IoC;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class BlocksController : Controller
        {
            public IBlockRepository _BlockRepository;
            private IStringLocalizer<SharedResource> _localizer;
            private readonly IMediator _mediator;
            private readonly IHttpContextAccessor _httpContext;
            private readonly UserManager<ApplicationUser> _userManager;

            public BlocksController(IBlockRepository BlockRepository, IStringLocalizer<SharedResource> localizer, IMediator mediator, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
            {
                _BlockRepository = BlockRepository;
                _localizer = localizer;
                _mediator = mediator;
                _httpContext = httpContext;
                _userManager = userManager;
            }

            // GET: BlockController
            public async Task<ActionResult> Index(BlockType blockType)
            {
                ViewData["Title"] = _localizer[blockType.DisplayName()];
                ViewData["BlockType"] = blockType;

                var Blocks = await _BlockRepository.GetBlocksAsync(blockType);
                if (Blocks.Any())
                {

                    return RedirectToAction("Edit", new { blockType, id = Blocks.Select(e => e.Id).FirstOrDefault() });
                }

                return RedirectToAction("Create", new { blockType });



                //return View(Blocks);

            }

            // GET: BlockController/Create
            public ActionResult Create(BlockType blockType)
            {
                ViewData["Main"] = _localizer[blockType.DisplayName()];
                ViewData["BlockType"] = blockType;

                return View();
            }

            // POST: BlockController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(BlockType blockType, Block Block)
            {
                ViewData["Main"] = _localizer[blockType.DisplayName()];
                ViewData["BlockType"] = blockType;

                if (ModelState.IsValid)
                {
                    try
                    {
                    Block.CreatedOnUtc = DateTime.SpecifyKind(Block.CreatedOnUtc, DateTimeKind.Utc);
                    Block.UpdatedOnUtc = DateTime.SpecifyKind(Block.UpdatedOnUtc, DateTimeKind.Utc);


                    var result = await _BlockRepository.AddBlockAsync(Block);
                        if (result)
                        {
                            if (blockType == BlockType.Contactus)
                            {
                                return RedirectToAction("Edit", new { blockType, id = Block.Id });
                            }

                            await _mediator.Publish(new LogAddViewModel()
                            {
                                ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                                IpAddress = Config.GetIpAddress(_httpContext),
                                Table = ControllerContext.ActionDescriptor.ControllerName,
                                Action = ControllerContext.ActionDescriptor.ActionName,
                                Details = $"Create {blockType} with Id {(Block.Id)}",
                            });
                            return RedirectToAction(nameof(Index), new { blockType });


                        }
                    }
                    catch
                    {
                    }

                }


                return View(Block);

            }

            // GET: BlockController/Edit/5
            public async Task<ActionResult> Edit(BlockType blockType, int id)
            {
                ViewData["BlockType"] = blockType;
                ViewData["Main"] = _localizer[blockType.DisplayName()];

                if (id == 0)
                {
                    return NotFound();
                }
                var Block = await _BlockRepository.GetBlockAsync(blockType, id);
             
                if (Block == null)
                {
                    return NotFound();

                }
                return View(Block);
            }

            // POST: BlockController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(BlockType blockType, int id, Block Block)
            {
                ViewData["Main"] = _localizer[blockType.DisplayName()];
                ViewData["BlockType"] = blockType;

                if (id != Block.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {

                        var result = await _BlockRepository.UpdateBlockAsync(Block);
                        if (result)
                        {
                       
                            await _mediator.Publish(new LogAddViewModel()
                            {
                                ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                                IpAddress = Config.GetIpAddress(_httpContext),
                                Table = ControllerContext.ActionDescriptor.ControllerName,
                                Action = ControllerContext.ActionDescriptor.ActionName,
                                Details = $"Edit {blockType} with Id {(Block.Id)}",
                            });
                            return RedirectToAction(nameof(Index), new { blockType });
                        }

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!(await IsBlockExist(Block.Id)))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }


                return View(Block);
            }

            public async Task<JsonResult> JsonDuplicate(int? id)
            {
                if (id == null)
                {
                    return Json("Failed");

                }
                var result = await _BlockRepository.DuplicateBlockAsync((int)id);
                if (result)
                {

                    await _mediator.Publish(new LogAddViewModel()
                    {
                        ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                        IpAddress = Config.GetIpAddress(_httpContext),
                        Table = ControllerContext.ActionDescriptor.ControllerName,
                        Action = ControllerContext.ActionDescriptor.ActionName,
                        Details = $"Duplicated with Id {(id)}",
                    });
                    return Json("Duplicated");
                }
                return Json("Failed");

            }

            public async Task<JsonResult> JsonDelete(int? id)
            {
                if (id == null)
                {
                    return Json("Failed");

                }
                var result = await _BlockRepository.DeleteBlockAsync((int)id);
                if (result)
                {
                    await _mediator.Publish(new LogAddViewModel()
                    {
                        ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                        IpAddress = Config.GetIpAddress(_httpContext),
                        Table = ControllerContext.ActionDescriptor.ControllerName,
                        Action = ControllerContext.ActionDescriptor.ActionName,
                        Details = $"Delete with Id {(id)}",
                    });

                    return Json("Removed");
                }
                return Json("Failed");
            }

            public async Task<bool> IsBlockExist(int id)
            {
                return await _BlockRepository.BlockAnyAsync(id);
            }
            public IActionResult BookingOverview()
            {
                return View();
            }
        }
    }

