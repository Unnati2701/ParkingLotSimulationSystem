using ParkingLotSimulation;
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("******************** Welcome To Parking Lot ********************");
        Console.WriteLine("Please provide the number of slots to initialize parking");

        Console.WriteLine("Enter number of 2 wheeler slots");
        int twoWheelersSlotsCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of 4 wheeler slots");
        int fourWheelerSlotsCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of heavy vehicle slots");
        int heavyVehicleSlotsCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Parking Lot initialization done!");

        ParkingLot parkingLot = new ParkingLot();
        parkingLot.Slots = new Dictionary<VehicleType, List<ParkingSlot>>();
        parkingLot.Tickets = new List<ParkingTicket>();


        var twoWheelerSlots = CreateSlots(twoWheelersSlotsCount);
        var fourWheelerSlots = CreateSlots(fourWheelerSlotsCount);
        var heavyVehicleSlots = CreateSlots(heavyVehicleSlotsCount);


        parkingLot.Slots.Add(VehicleType.TwoWheeler, twoWheelerSlots);
        parkingLot.Slots.Add(VehicleType.FourWheeler, fourWheelerSlots);
        parkingLot.Slots.Add(VehicleType.HeavyVehicle, heavyVehicleSlots);


        while (true)
        {

            Console.WriteLine("Please choose the action to be performed \n1. Check Availability \n2. Park Vehicle \n3. Unpark Vehicle");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Vehicle Type. \n0 For Two Wheeler \n1 For Four Wheeler \n2 For Heavy Vehicle ");
            int vehicleType = Convert.ToInt32(Console.ReadLine());
            VehicleType type = (VehicleType)vehicleType;
            switch (i)
            {
                case 1:
                    int x = parkingLot.Slots[type].Where(f => f.IsParked == false).Count();
                    Console.WriteLine("Availabile space for {0} is {1}", type, x);
                    break;


                case 2:
                    Console.WriteLine("Enter the Vehicle Number to park");
                    string number = Console.ReadLine();
                    var z = parkingLot.Slots[type].Where(f => f.IsParked == false).FirstOrDefault();

                    if (z != null)
                    {
                        z.VehicleDetail = new Vehicle { VehicleNumber = number, Type = type };
                        z.IsParked = true;
                        ParkingTicket recentTicket = new ParkingTicket()
                        {
                            VehicleNumber = z.VehicleDetail.VehicleNumber,
                            SlotNumber = z.Number,
                            InTime = DateTime.Now
                        };
                        parkingLot.Tickets.Add(new ParkingTicket()
                        {
                            VehicleNumber = number,
                            SlotNumber = z.Number,
                            InTime = DateTime.Now
                        });
                        Console.WriteLine("Your Ticket\n");
                        Console.WriteLine("Vehicle Number - {0} \nSlot Number - {1} \nIn Time - {2}",recentTicket.VehicleNumber, recentTicket.SlotNumber, recentTicket.InTime);

                        Console.WriteLine("Parked {0}", type);
                    }
                    else
                    {
                        Console.WriteLine("No slot available to park, please check availability first");
                    }


                    break;


                case 3:
                    Console.WriteLine("Enter vehicle number to unpark");
                    string vehicleNumber = Console.ReadLine();
                    ParkingSlot y = parkingLot.Slots[type].Where(f => f.VehicleDetail?.VehicleNumber == vehicleNumber)?.FirstOrDefault();
                    if (y != null)
                    {
                        y.IsParked = false;
                        Console.WriteLine("Vehicle Unparked");
                    }
                    else
                    {
                        Console.WriteLine("There is no vehicle of vehicle number {0} parked.Enter the valid vehicle type and number", vehicleNumber);
                    }


                    break;

                default:

                    Console.WriteLine("Enter the valid number");
                    break;

            }
        }


    }

    private static List<ParkingSlot> CreateSlots(int numberOfSlots)
    {
        List<ParkingSlot> slots = new List<ParkingSlot>();
        for (int i = 0; i < numberOfSlots; i++)
        {
            slots.Add(new ParkingSlot()
            {
                Number = i + 1,
                IsParked = false
            });
        }
        return slots;
    }
}