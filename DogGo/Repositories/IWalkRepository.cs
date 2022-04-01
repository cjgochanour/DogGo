using System.Collections.Generic;
using DogGo.Models;
namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAllWalks();
        List<Walk> GetWalksByWalkerId(int id);
        void AddWalk(Walk walk);
    }
}
