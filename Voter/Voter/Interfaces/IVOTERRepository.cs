using Voter.Models;

namespace Voter.Interfaces
{
    public interface IVOTERRepository
    {
        public int SaveVote(VoterModel model, string REC_TYPE);
        public List<VoterModel> GetVote(int VOTER_kEY);
        public int DeleteVote(VoterModel model, string REC_TYPE);
        public List<VoterModel> getState(int STATE_ID);
 //     public List<VoterModel> getCity(int STATE_ID, int CITY_ID)
        public List<VoterModel> getGender(int GENDER_ID);
    }
}
