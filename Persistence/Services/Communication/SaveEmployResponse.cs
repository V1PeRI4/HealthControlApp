using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Services.Communication
{
    public class SaveEmployResponse : BaseResponse
    {
        public Employ Employ { get; private set; }

        private SaveEmployResponse(bool success, string massage, Employ employ) : base(success, massage)
        {
            Employ = employ;
        }

        public SaveEmployResponse(Employ employ) : this(true, string.Empty, employ) { }

        public SaveEmployResponse(string massage) : this(false, massage, null) { }

    }
}
