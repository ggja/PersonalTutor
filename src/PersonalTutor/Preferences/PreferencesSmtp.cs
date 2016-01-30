
namespace PersonalTutor.Preferences
{
    public sealed class PreferencesSmtp
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public string FromMailbox { get; set; } 
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }


        private PreferencesSmtp()
        {
            
        }

        static PreferencesSmtp _instance;

        public static PreferencesSmtp Instance {
            get
            {
                _instance = _instance ?? new PreferencesSmtp();
                return _instance;
            }
        }
    


    }
}
