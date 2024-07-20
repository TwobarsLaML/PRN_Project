using BusinessObjects;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace HotelManagementWPFApp
{
    /// <summary>
    /// Interaction logic for UpdateRoom.xaml
    /// </summary>
    public partial class UpdateRoom : Window
    {
        private Admin admin;
        private RoomInformation room;


        public UpdateRoom()
        {
            InitializeComponent();
        }

        private void LoadRoomType()
        {
            // get all room type
            List<RoomType> roomTypes = RoomTypeReposity.GetAllRoomTypes();
            cboRoomType.ItemsSource = roomTypes;
            cboRoomType.DisplayMemberPath = "RoomTypeName";
            cboRoomType.SelectedValuePath = "RoomTypeId";
        }

        private void btnSave_Clicked(object sender, RoutedEventArgs e)
        {

            // get form field
            string roomNum = txtRoomNumber.Text;
            string description = txtDescription.Text;
            string capacity = txtMaxCapacity.Text;
            string price = txtPricePerDay.Text;
            string roomType = cboRoomType.SelectedValue.ToString();

            // validation
            if (string.IsNullOrEmpty(price) || string.IsNullOrEmpty(roomNum)
                || string.IsNullOrEmpty(capacity) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Please fill in all the information");
                return;
            }
            List<RoomInformation> rooms = RoomRepository.GetAllRooms();
            foreach (RoomInformation r in rooms)
            {
                if (roomNum.Equals(r.RoomNumber))
                {
                    MessageBox.Show("Please input new Room No.");
                    return;
                }
            }

            // update room info
            room.RoomDetailDescription = description;
            room.RoomNumber = roomNum;
            room.RoomMaxCapacity = int.Parse(capacity);
            room.RoomTypeId = int.Parse(roomType);
            room.RoomPricePerDay = int.Parse(price);

            // update room
            RoomRepository.UpdateRoom(room);
            // reload room data grid
            admin.LoadRoom();
            admin.LoadBookingDetail();
            this.Close();
        }

        private void btnCancel_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SetAdmin(Admin admin)
        {
            this.admin = admin;
        }

        public void SetRoom(RoomInformation room)
        {
            this.room = room;
            LoadRoomType();
            SetRoomInfo();
        }

        private void SetRoomInfo()
        {
            txtDescription.Text = room.RoomDetailDescription;
            txtMaxCapacity.Text = room.RoomMaxCapacity.ToString();
            txtPricePerDay.Text = room.RoomPricePerDay.ToString().Split(".")[0];
            txtRoomNumber.Text = room.RoomNumber;
            cboRoomType.SelectedValue = room.RoomTypeId;
        }

    }
}
