namespace Ex03.GarageLogic.Garage
{
    public class GarageClient
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhone;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public GarageClient(string i_VehicleOwnerName, string i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
            this.m_VehicleOwnerName = i_VehicleOwnerName;
            this.m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            this.m_VehicleStatus = eVehicleStatus.InRepair;
            this.m_Vehicle = i_Vehicle;
        }

        public string VehicleOwnerName
        {
            get
            {
                return m_VehicleOwnerName;
            }

            set
            {
                m_VehicleOwnerName = value;
            }
        }

        public string VehicleOwnerPhone
        {
            get
            {
                return m_VehicleOwnerPhone;
            }

            set
            {
                m_VehicleOwnerPhone = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public enum eVehicleStatus
        {
            InRepair=1,
            Fixed=2,
            PaidUp=3
        }
    }
}
