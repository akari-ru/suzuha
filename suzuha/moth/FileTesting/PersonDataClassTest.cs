﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace suzuha.moth.FileTesting
{
    [DataContract]
    class PersonDataClassTest {
        
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public int Id { get; set; }
    }
}