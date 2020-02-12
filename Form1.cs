using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data.OleDb;

namespace WorkOrderCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWOGenerator_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Work Order Creation Started";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                       SecurityProtocolType.Tls11 |
                                       SecurityProtocolType.Tls12;
            var serviceLocationString = RequestCreator("https://staging-api.fmpilot2.com/Mobile/api/ServiceLocations");
            List<RequestTypeResponse> serviceLocationResponse = JsonConvert.DeserializeObject<List<RequestTypeResponse>>(serviceLocationString.ToString());

            Random random = new Random();


            for (int i = 0; i < Convert.ToInt32(txtNumberOfWorkOrders.Text); i++)
            {

                try
                {
                    RequestTypeResponse requestType = (RequestTypeResponse)lstRequestTypes.SelectedItems[random.Next(0, lstRequestTypes.SelectedItems.Count)];
                    int requestTypeID = Convert.ToInt32(requestType.Id);
                    int locationID = Convert.ToInt32(cmbLocations.SelectedValue);

                    var requestCodeString = RequestCreator(String.Format("https://staging-api.fmpilot2.com/Mobile/api/RequestCodes?RequestTypeId={0}&locationId={1}", requestTypeID, locationID));
                    List<RequestTypeResponse> requestCodeResponse = JsonConvert.DeserializeObject<List<RequestTypeResponse>>(requestCodeString.ToString());

                    WorkOrder workOrder = new WorkOrder();
                    workOrder.AlternateContact = "";
                    workOrder.AlternateWorkOrderNumber = "";
                    workOrder.Department = "";
                    workOrder.Description = txtDescription.Text;
                    workOrder.IsEmergency = false;
                    workOrder.LocationNumber = locationID;
                    workOrder.Priority = "";
                    workOrder.Dne = 0;
                    workOrder.RequestType = requestTypeID;
                    workOrder.RequestCode = (requestCodeResponse.ToArray()[random.Next(0, requestCodeResponse.ToArray().Length)]).Id;
                    workOrder.RequestingContact = txtContactName.Text;
                    workOrder.ServiceLocation = (serviceLocationResponse.ToArray()[random.Next(0, serviceLocationResponse.ToArray().Length)]).Id;
                    workOrder.VendorCode = txtVendorCode.Text;
                    workOrder.WorkOrderType = "";
                    workOrder.WorkType = "";
                    workOrder.Equipment = "";
                    workOrder.StatusCode = "PAC";
                    var request = (HttpWebRequest)WebRequest.Create("https://staging-api.fmpilot2.com/Mobile/api/WorkOrders");
                    request.Headers.Add("Authorization", "Bearer " + txtAuthToken.Text);
                    string json = JsonConvert.SerializeObject(workOrder);
                    var data = Encoding.ASCII.GetBytes(json);
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=utf-8";
                    request.ContentLength = data.Length;
                    request.Headers["authenticationToken"] = "dc0da435-6643-4b09-9567-bb65d5750e53";
                    request.Headers["sourceDomain"] = "MOFAM";
                    request.Headers["actingDomain"] = txtActingDomain.Text;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    WorkOrderResponse workOrderResponse = JsonConvert.DeserializeObject<WorkOrderResponse>(responseString.ToString());
                    InsertIntoExcel("TestWO.xlsx", workOrderResponse);
                    lblStatus.Text = (i + 1) + " Work Orders Created";
                }
                catch
                {

                }

            }
        }

        public bool InsertIntoExcel(string ExcelFileName, WorkOrderResponse workOrderResponse)
        {
            bool isDataInserted = false;
            string ConStr = "";
            //getting the path of the file     
            string path = ExcelFileName;
            //connection string for that file which extantion is .xlsx    
            ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
            //making query    
            string query = "INSERT INTO [Workorder$] (Client,Store,WorkOrderNumber,ServiceLocation,RequestType,RequestCode,VendorCode,PasteInDescription,DNE,Priority,RequestingContact) VALUES (@Client,@Store,@WorkOrderNumber,@ServiceLocation,@RequestType,@RequestCode,@VendorCode,@PasteInDescription,@DNE,@Priority,@RequestingContact)";
            //Providing connection    
            OleDbConnection conn = new OleDbConnection(ConStr);
            //checking that connection state is closed or not if closed the     
            //open the connection    
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //create command object    
            OleDbCommand cmd = new OleDbCommand(query, conn);

            cmd.Parameters.Add("@Client", txtActingDomain.Text);
            cmd.Parameters.Add("@Store", workOrderResponse.Location.StoreNumber);
            cmd.Parameters.Add("@WorkOrderNumber", workOrderResponse.WorkOrderNumber);
            cmd.Parameters.Add("@ServiceLocation", workOrderResponse.ServiceLocationName);
            cmd.Parameters.Add("@RequestType", workOrderResponse.RequestType);
            cmd.Parameters.Add("@RequestCode", workOrderResponse.RequestCode);
            cmd.Parameters.Add("@VendorCode", txtVendorCode.Text);
            cmd.Parameters.Add("@PasteInDescription", workOrderResponse.Description);
            cmd.Parameters.Add("@DNE", workOrderResponse.Dne);
            cmd.Parameters.Add("@Priority", workOrderResponse.Priority);
            cmd.Parameters.Add("@RequestingContact", workOrderResponse.RequestingContact);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                isDataInserted = true;
            }
            conn.Close();
            return isDataInserted;
        }

        private void btnLoadLocations_Click(object sender, EventArgs e)
        {
            var responseString = RequestCreator("https://staging-api.fmpilot2.com/Mobile/api/Locations?page=0&pageSize=25");
            List<LocationResponse> locationResponse = JsonConvert.DeserializeObject<List<LocationResponse>>(responseString.ToString());
            cmbLocations.SelectedIndexChanged -= cmbLocations_SelectedIndexChanged;
            cmbLocations.DataSource = locationResponse;
            cmbLocations.ValueMember = "Id";
            cmbLocations.DisplayMember = "StoreName";
            cmbLocations.SelectedIndexChanged += cmbLocations_SelectedIndexChanged;
        }

        private void cmbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            int locationID = Convert.ToInt32(cmbLocations.SelectedValue);
            var responseString = RequestCreator("https://staging-api.fmpilot2.com/Mobile/api/RequestTypes?locationId=" + locationID);
            List<RequestTypeResponse> locationResponse = JsonConvert.DeserializeObject<List<RequestTypeResponse>>(responseString.ToString());
            lstRequestTypes.DataSource = locationResponse;
            lstRequestTypes.ValueMember = "Id";
            lstRequestTypes.DisplayMember = "Name";
        }

        public string RequestCreator(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                      SecurityProtocolType.Tls11 |
                                      SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "Bearer " + txtAuthToken.Text);
            request.Method = "GET";
            request.Headers["authenticationToken"] = "f54b4e33-edff-42bd-b98e-ce34e6a23ac8";
            request.Headers["sourceDomain"] = "MOFAM";
            request.Headers["actingDomain"] = txtActingDomain.Text;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
