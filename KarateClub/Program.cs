using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KarateClub.Login;
using KarateClub.Main;
using KarateClub.Members;
using KarateClub.Users;
using KarateClub.MembersInstructors;
using KarateClub.BeltTests;

namespace KarateClub
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
