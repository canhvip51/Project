using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData
{
        public class ApplicationDbContexts
        {
            SHOESSHOPEntities db = new SHOESSHOPEntities();

            public SHOESSHOPEntities ApplicationDbContext { get { return db; } }
        }
        //public class ApplicationDbMsgContexts
        //{
        //    openfireV2Entities db = new openfireV2Entities();
        //    public openfireV2Entities ApplicationDbMsgContext { get { return db; } }
        //}
}
