using Byteable.Models;
using System.Net.Mail;
using System.Net;

namespace Byteable.CodeRepo
{
    public class RegCompRepo : IRegComp
    {
        private ByteableDbContext _db;
        MailMessage message = new MailMessage();

        public RegCompRepo(ByteableDbContext db)
        {
            _db = db; 
        }

        public void AddTeam(RegCompDTO team)
        {
            var _comp = (Competition)team._CompetitionType;
            string Comp = _comp.ToString();

            int fee;
            if (team.ClubMember)
            {
                fee= 500;
            }
            else
            {
                fee = 1000; 
            }

            //byte[] filebyte = new byte[receipt.Length];
            //MemoryStream stream = new MemoryStream();
            //receipt .CopyTo(stream);
            //filebyte = stream.ToArray();

            RegComp regComp = new RegComp() 
            {
                TeamName= team.TeamName,
                ParticipantNo= team.ParticipantNo,
                CompetitionType = Comp,
                ClubMember = team.ClubMember,
                RegistrationFee= fee,
                PaymentReceipt = new byte[]{}, 
                Participants = new List<Participants>(){ }
            };

            _db.RegisterCompetitions.Add(regComp);
            _db.SaveChanges();
        }

        public void AddParticipants(ParticipantDTO participant)
        {
            var Team = _db.RegisterCompetitions.OrderByDescending(x => x.ID).FirstOrDefault();

            Participants participants = new Participants()
            {
                ParticipantName = participant.Name,
                ParticipantEmail= participant.Email,
                ParticipantPhone= participant.Phone,
                TeamName = Team.TeamName
            };

            if (Team.Participants == null)
            {
                Team.Participants =new List<Participants>();
            }

            // SendEmail(participant.Name, participant.Email); 
            Team.Participants.Add(participants);
            _db.Update(Team);
            _db.SaveChanges();
        }
        public void SendEmail(string name, string email)
        {
            string particpant_email = email;

            message.From = new MailAddress("byteable01@outlook.com");
            message.To.Add(new MailAddress(particpant_email));

            message.Subject = "Team Registration Confirmation";

            string messagebody = "Dear " + name +
                ",\r\n\r\nWe are delighted to confirm that you have successfully registered for the upcoming competition organized by Byteable Code Club. Thank you for showing your interest in our club and for participating in this event.\r\n\r\nPlease note that you will receive further instructions and details regarding the competition through email, including the competition rules and regulations. We advise you to go through these instructions carefully to ensure that you are well prepared for the competition.\r\n\r\nIf you have any questions or concerns, please do not hesitate to contact us. We are always here to assist you in any way we can.\r\n\r\nOnce again, we thank you for your registration and participation, and we wish you the best of luck in the competition.\r\n\r\nBest regards,\r\n\r\nByteable Code Club\r\n\r\n\r\n\r\n\r\n\r\n";

            message.Body = messagebody;


            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new NetworkCredential("byteable01@outlook.com", "Byteable123");
            client.EnableSsl = true;
            client.Send(message);

        }
        //Byteable Outlook Account Credentials
        //byteable01 @outlook.com
        //Byteable123
    }
}
