using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IBlockRepository
    {
        public Task<bool> AddBlockAsync(Block Block);
        public Task<bool> DeleteBlockAsync(int id);
        public Task<bool> DuplicateBlockAsync(int id);
        public IQueryable<Block> GetBlockApiAsync();
        public Task<Block?> GetBlockAsync(BlockType BlockType, int id, bool hidden = false);
        public Task<IEnumerable<Block>> GetBlocksAsync(BlockType BlockType, bool hidden = false);
        public Task<Block?> GetBlockshomepage(BlockType BlockType, bool hidden = false);
        public Task<bool> UpdateBlockAsync(Block Block);
        public Task<bool> BlockAnyAsync(int id);
        public Task<BlockVM?> GetAPIBlockVMAsync(BlockType BlockType, string? language);
        









    }

}
