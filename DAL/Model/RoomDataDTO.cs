using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class RoomDataDTO
    {
        private HardwareDTO hardware;
        private int idRoom;
        private string value;
        private string state;
        private string dataTypeName;

        public HardwareDTO Hardware
        {
            get => hardware;
            set => hardware = value;
        }
        public int IdRoom
        {
            get => idRoom;
            set => idRoom = value;

        }

        public string State
        {
            get => state;
            set => state = value;
        }

        public string Value
        {
            get => value;
            set => this.value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string DataTypeName
        {
            get => dataTypeName;
            set => dataTypeName = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
