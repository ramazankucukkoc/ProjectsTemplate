using Application.Services.Repositories;

namespace Application.Services.FindeksCreditRateService
{
    public class FindeksCreditRateManager : IFindeksCreditRateService
    {
        private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;

        public FindeksCreditRateManager(IFindeksCreditRateRepository findeksCreditRateRepository)
        {
            _findeksCreditRateRepository = findeksCreditRateRepository;
        }

        public short GetScore(string identityNumber)
        {
            Random random = new();
            short score = Convert.ToInt16(random.Next(1900));
            return score;
        }
    }
}
