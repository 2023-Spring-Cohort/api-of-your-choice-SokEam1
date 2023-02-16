using EldenRing.Models;
using EldenRingTutorial.Context;
using EldenRingTutorial.Repositories.Interfaces;

namespace EldenRingTutorial.Repositories
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(GameContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
