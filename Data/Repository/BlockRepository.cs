using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BlockRepository : IBlockRepository
    {
        private readonly WriteDbContext _context;
        private readonly ReadDBContext _read;
        private readonly IMapper _mapper;

        public BlockRepository(WriteDbContext context, IMapper mapper, ReadDBContext read)
        {
            _context = context;
            _mapper = mapper;
            _read = read;
        }


        public async Task<bool> AddBlockAsync(Block Block)
        {
            try
            {

                await _context.AddAsync(Block);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        }

        public async Task<bool> UpdateBlockAsync(Block Block)
        {
            try
            {
                _context.Update(Block);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public async Task<bool> DeleteBlockAsync(int id)
        {
            try
            {
                var Block = await _context.Blocks.FirstOrDefaultAsync(e => e.Id == id);
                if (Block == null)
                    return false;

                Block.Deleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<bool> DuplicateBlockAsync(int id)
        {
            try
            {
                var Block = await _context.Blocks.FirstOrDefaultAsync(e => e.Id == id);
                if (Block != null)
                {
                    var dublicatedBlock = new Block
                    {
                        ArName = Block.ArName,
                        EnName = Block.EnName,
                        CreatedOnUtc = Extantion.AddUtcTime(),
                        DisplayOrder = Block.DisplayOrder,
                        Hidden = Block.Hidden,
                        ArContent = Block.ArContent,
                        EnContent = Block.EnContent,
                        Location = Block.Location,
                        Deleted = Block.Deleted,
                        BlockType = Block.BlockType,
                        ArPicture = Block.ArPicture,
                        EnPicture = Block.EnPicture,
                        UpdatedOnUtc = Extantion.AddUtcTime(),
                    };
                    await _context.AddAsync(dublicatedBlock);
                    await _context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

            }
            return false;

        }

        public async Task<Block?> GetBlockAsync(BlockType BlockType, int id, bool hidden = false)
        {
            return await _read.Blocks.Where(e => e.Id == id && e.BlockType == BlockType && (hidden == false || e.Hidden != hidden)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Block>> GetBlocksAsync(BlockType BlockType, bool hidden = false)
        {
            return await _read.Blocks.Where(e => e.BlockType == BlockType && (hidden == false || e.Hidden != hidden)).ToListAsync();
        }

        public async Task<Block> GetBlockshomepage(BlockType BlockType, bool hidden = false)
        {
            return await _read.Blocks.Where(e => e.BlockType == BlockType && !e.Hidden).FirstOrDefaultAsync();
        }
        public IQueryable<Block> GetBlockApiAsync()
        {
            return _read.Blocks;
        }
        public async Task<BlockVM?> GetAPIBlockVMAsync(BlockType BlockType, string? language)
        {
            return await _read.Blocks.Where(e => !e.Hidden && e.BlockType != BlockType.FeedbackEmailToAdmin && e.BlockType != BlockType.FeedbackEmailToUser && e.BlockType == BlockType)
                .OrderBy(e => e.DisplayOrder).ThenByDescending(e => e.Id)
                .ProjectTo<BlockVM>(_mapper.ConfigurationProvider, new { language })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> BlockAnyAsync(int id)
        {
            return await _read.Blocks.AnyAsync(e => e.Id == id);
        }


        

    }
}
