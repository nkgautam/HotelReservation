using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Protocols;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using SiteminderWCF.SiteConnect;

namespace SiteminderWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "XMLData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select XMLData.svc or XMLData.svc.cs at the Solution Explorer and start debugging.


    public class XMLData : IXMLData
    {
        string security = @"<SOAP-ENV:Header xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>
    <wsse:Security soap:mustUnderstand='1' xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
      <wsse:UsernameToken>
        <wsse:Username>EvasionVoyage</wsse:Username>
        <wsse:Password Type='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText'>4ez7ak4zQ5srEeq</wsse:Password>
      </wsse:UsernameToken>
    </wsse:Security>
  </SOAP-ENV:Header>";

        string xml = @"<OTA_HotelResNotifRQ xmlns='http://www.opentravel.org/OTA/2003/05' Version='1.0' EchoToken='echo-abc123' ResStatus='Commit' TimeStamp='2012-03-09T21:32:52+02:00'>
  <POS>
    <Source>
      
      <RequestorID Type='22' ID='EVG'/>
      <BookingChannel Primary='true' Type='1'>
        <CompanyName Code='GD'>My GDS</CompanyName>
      </BookingChannel>
    </Source>
    <Source>
      <BookingChannel Type='2'>
        <CompanyName Code='LC'>Lodging</CompanyName>
      </BookingChannel>
    </Source>
  </POS>
  <HotelReservations>
    <HotelReservation CreateDateTime='2012-03-09T21:31:52+02:00'>
      <UniqueID Type='14' ID='3741'/>
      <RoomStays>
        <RoomStay PromotionCode='breakkie'>
          <RoomTypes>
            <RoomType RoomTypeCode='ROOM1'>
              <RoomDescription Name='Standard Room'>Standard Room with double bed and single bed</RoomDescription>
            </RoomType>
          </RoomTypes>
          <RatePlans>
            <RatePlan RatePlanCode='RATE1'>
              <RatePlanDescription>Breakfast rate</RatePlanDescription>
              <Commission>
                <CommissionPayableAmount Amount='60.00' CurrencyCode='AUD'/>
              </Commission>
            </RatePlan>
          </RatePlans>
          <RoomRates>
            <RoomRate RoomTypeCode='ROOM1' RatePlanCode='RATE1' NumberOfUnits='1'>
              <Rates>
                <Rate UnitMultiplier='1' RateTimeUnit='Day' EffectiveDate='2012-03-12' ExpireDate='2012-03-14'>
                  <Base AmountBeforeTax='558.00' AmountAfterTax='620.00' CurrencyCode='AUD'>
                    <Taxes>
                      <Tax Amount='62.00' CurrencyCode='AUD'/>
                    </Taxes>
                  </Base>
                  <Total AmountBeforeTax='558.00' AmountAfterTax='620.00' CurrencyCode='AUD'>
                    <Taxes>
                      <Tax Amount='62.00' CurrencyCode='AUD'/>
                    </Taxes>
                  </Total>
                </Rate>
              </Rates>
            </RoomRate>
          </RoomRates>
          <GuestCounts IsPerRoom='1'>
            <GuestCount AgeQualifyingCode='10' Count='2'/>
            <GuestCount AgeQualifyingCode='8' Count='1'/>
            <GuestCount AgeQualifyingCode='7' Count='1'/>
          </GuestCounts>
          <TimeSpan Start='2012-03-12' End='2012-03-14'/>
          <Total AmountBeforeTax='558.00' AmountAfterTax='620.00' CurrencyCode='AUD'>
            <Taxes>
              <Tax Amount='62.00' CurrencyCode='AUD'/>
            </Taxes>
          </Total>
          <BasicPropertyInfo HotelCode='HOTEL1' HotelName='Evasion Voyage' />
          <ResGuestRPHs>
            <ResGuestRPH RPH='1'/>
          </ResGuestRPHs>
          <Comments>
            <Comment>
              <Text>Will be Travelling with my friend so connected rooms please.</Text>
            </Comment>
          </Comments>
          <SpecialRequests>
            <SpecialRequest Name='extra bed'>
              <Text>Yes</Text>
            </SpecialRequest>
            <SpecialRequest Name='bedding configuration'>
              <Text>2 x Double</Text>
            </SpecialRequest>
          </SpecialRequests>
        </RoomStay>
      </RoomStays>
      <ResGuests>
        <ResGuest ResGuestRPH='1' ArrivalTime='14:00:00' PrimaryIndicator='1'>
          <Profiles>
            <ProfileInfo>
              <Profile ProfileType='1'>
                <Customer>
                  <PersonName>
                    <NamePrefix>Mr</NamePrefix>
                    <GivenName>John</GivenName>
                    <Surname>Smith</Surname>
                  </PersonName>
                  <Telephone PhoneNumber='0266564100'/>
                  <Email>test@siteminder.com.au</Email>
                  <Address>
                    <AddressLine>George St</AddressLine>
                    <AddressLine>CBD</AddressLine>
                    <CityName>Sydney</CityName>
                    <PostalCode>2000</PostalCode>
                    <StateProv>NSW</StateProv>
                    <CountryName Code='AU'>Australia</CountryName>
                  </Address>
                </Customer>
              </Profile>
            </ProfileInfo>
          </Profiles>
        </ResGuest>
      </ResGuests>
      <ResGlobalInfo>
        <Total CurrencyCode='AUD' AmountBeforeTax='558.00' AmountAfterTax='620.00'>
          <Taxes>
            <Tax Amount='62.00' CurrencyCode='AUD'/>
          </Taxes>
        </Total>
       
        <Guarantee>
          <GuaranteesAccepted>
            <GuaranteeAccepted>
              <PaymentCard CardNumber='4321432143214327' CardType='1' ExpireDate='0614' SeriesCode='123' CardCode='VI'>
                <CardHolderName>John Smith</CardHolderName>
              </PaymentCard>
            </GuaranteeAccepted>
          </GuaranteesAccepted>
        </Guarantee>
        <DepositPayments>
          <GuaranteePayment>
            <AcceptedPayments>
              <AcceptedPayment>
                <PaymentCard CardNumber='4321432143214327' CardType='1' ExpireDate='0614' SeriesCode='123' CardCode='VI'>
                  <CardHolderName>John Smith</CardHolderName>
                </PaymentCard>
              </AcceptedPayment>
            </AcceptedPayments>
            <AmountPercent Amount='62.00' CurrencyCode='AUD'/>
          </GuaranteePayment>
        </DepositPayments>
        <Profiles>
          <ProfileInfo>
            <Profile>
              <Customer>
                <PersonName>
                  <NamePrefix>Mr</NamePrefix>
                  <GivenName>John</GivenName>
                  <Surname>Smith</Surname>
                </PersonName>
                <Telephone PhoneNumber='0266564100'/>
                <Email>test@siteminder.com.au</Email>
                <Address>
                  <AddressLine>George St</AddressLine>
                  <AddressLine>CBD</AddressLine>
                  <CityName>Sydney</CityName>
                  <PostalCode>2000</PostalCode>
                  <StateProv>NSW</StateProv>
                  <CountryName Code='AU'>Australia</CountryName>
                </Address>
              </Customer>
            </Profile>
          </ProfileInfo>
        </Profiles>
      </ResGlobalInfo>
    </HotelReservation>
  </HotelReservations>
</OTA_HotelResNotifRQ>

";
        public SiteMinderVersionResponse About()
        {
            SiteMinderVersionResponse r = new SiteMinderVersionResponse();
            r.ServiceResponse = new serviceInfo();
            r.ServiceResponse.ServiceName = "SiteMinder WCF";
            r.ServiceResponse.Version = "20150308";
            return r;
        }

        
        public OTAResponse HotelAvailRQ(OTARequest request)
            {
            //Logs
            mysql.executesql("insert into wcf_logs (wcf_message) values ('HotelAvailRQ" + request.OTA_HotelAvailRQ.TimeStamp.ToString() + "')");
            
            


            var response = new OTAResponse();
            OTA_HotelAvailRS _OTA_HotelAvailRS = new OTA_HotelAvailRS() { RoomStays = new List<RoomStay>() };
            _OTA_HotelAvailRS.Success = new Success();

           

            response.OTA_HotelAvailRS = _OTA_HotelAvailRS;


            response.OTA_HotelAvailRS.EchoToken = request.OTA_HotelAvailRQ.EchoToken.ToString();
            response.OTA_HotelAvailRS.TimeStamp = request.OTA_HotelAvailRQ.TimeStamp.ToString();
            response.OTA_HotelAvailRS.Version = request.OTA_HotelAvailRQ.Version.ToString();

            SqlDataReader rdr = null; //SQL Data Reader Baglantisi
            string connectString = ConfigurationManager.AppSettings["myConnectionString"]; using (SqlConnection conn = new SqlConnection(connectString))
            using (SqlCommand cmd = conn.CreateCommand())
                {
                conn.Open();
                cmd.CommandText = "Select  location_id,room_type,room_text,room_type_code,room_rate_plan_code,room_rate_plan_description_name,  room_rate_plan_description_text from v_siteminder_OTA_HotelAvailRQ where location_id=1";
                cmd.Connection = conn;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    {
                    RoomStay _RoomStay = new RoomStay() { RoomTypes = new List<RoomType>(), RatePlans = new List<RatePlan>() };
                    RoomType _RoomType = new RoomType();
                    RatePlan _RatePlan = new RatePlan();

                    _RoomStay.RoomTypes.Add(_RoomType);
                    _RoomStay.RatePlans.Add(_RatePlan);

                    RoomDescription _RoomDescription = new RoomDescription();
                    _RoomType.RoomDescription = _RoomDescription;
                    RatePlanDescription _RatePlanDescription = new RatePlanDescription();
                    _RatePlan.RatePlanDescription = _RatePlanDescription;

                    _RoomType.RoomTypeCode = rdr["room_type_code"].ToString(); // room_type_code
                    _RatePlan.RatePlanCode = rdr["room_rate_plan_code"].ToString(); // 

                    _RoomDescription.Name = rdr["room_type"].ToString();  // room_type in database
                    _RoomDescription.Text = rdr["room_text"].ToString(); // room_text in database


                    _RatePlanDescription.Name = rdr["room_rate_plan_description_name"].ToString(); // room_rate_plan_description_name
                    _RatePlanDescription.Text = rdr["room_rate_plan_description_text"].ToString(); // room_rate_plan_description_text

                    _OTA_HotelAvailRS.RoomStays.Add(_RoomStay);

                    }

                rdr.Close();
                return response;

                }
            }


        public OTAHotelAvailNotifRS HotelAvailNotifRQ(OTAHotelAvailPush request)
            {
            
            var response = new OTAHotelAvailNotifRS();
            OTA_HotelAvailNotifRS _x = new OTA_HotelAvailNotifRS();
            _x.Success = new Success();
            response.OTA_HotelAvailNotifRS = _x;

            response.OTA_HotelAvailNotifRS.EchoToken = request.OTA_HotelAvailNotifRQ.EchoToken.ToString();
            response.OTA_HotelAvailNotifRS.TimeStamp = request.OTA_HotelAvailNotifRQ.TimeStamp.ToString();
            response.OTA_HotelAvailNotifRS.Version = request.OTA_HotelAvailNotifRQ.Version.ToString();

            // now u can use for each loop.

      
            //_SiteMinderUpdateResponse y = new _SiteMinderUpdateResponse();

          
            //x.UpdateResponse= y;

            //// u can use foreach here
            //y.HotelCode = request.OTA_HotelAvailNotifRQ.AvailStatusMessages.HotelCode.ToString();

            //y.Start = request.OTA_HotelAvailNotifRQ.AvailStatusMessages.AvailStatusMessage[0] .StatusApplicationControl.Start;
            //y.End = request.OTA_HotelAvailNotifRQ.AvailStatusMessages.AvailStatusMessage[0].StatusApplicationControl.End;
            //y.InvTypeCode = request.OTA_HotelAvailNotifRQ.AvailStatusMessages.AvailStatusMessage[0].StatusApplicationControl.InvTypeCode;
            //y.RatePlanCode = request.OTA_HotelAvailNotifRQ.AvailStatusMessages.AvailStatusMessage[0].StatusApplicationControl.RatePlanCode;

            mysql.executesql("insert into wcf_logs (wcf_message) values (' OTAHotelAvailNotifRS" + request.OTA_HotelAvailNotifRQ.TimeStamp.ToString() + "')");
            

            return response;

            }


        public OTAHotelRateAmountNotifRS HotelRateAmountNotifRQ(OTAHotelRateAmountPush request)
        {

        var response = new OTAHotelRateAmountNotifRS();

        OTA_HotelRateAmountNotifRS _x = new OTA_HotelRateAmountNotifRS();
        _x.Success = new Success();

        response.OTA_HotelRateAmountNotifRS = _x;


        response.OTA_HotelRateAmountNotifRS.EchoToken = request.OTA_HotelRateAmountNotifRQ.EchoToken.ToString();
        response.OTA_HotelRateAmountNotifRS.TimeStamp = request.OTA_HotelRateAmountNotifRQ.TimeStamp.ToString();
        response.OTA_HotelRateAmountNotifRS.Version = request.OTA_HotelRateAmountNotifRQ.Version.ToString();


        mysql.executesql("insert into wcf_logs (wcf_message) values ('HotelRateAmountNotifRQ" + request.OTA_HotelRateAmountNotifRQ.TimeStamp.ToString() + "')");
            
        return response;
                    // now u can use for each loop.

        }

        
        
        public OTAHotelResNotifRS HotelResNotifRQ(String requestorID)
        {
            var response = new OTAHotelResNotifRS();

            var siteConnect = new SiteConnect.SiteConnectServiceClient();
            var securityHeader = new SiteConnect.SecurityHeaderType();
            
            //var xmlNode = new xmlNode();
            
            var ota_hotel = new SiteConnect.OTA_HotelResNotifRQ();

                      
            ota_hotel.EchoToken = "echo-abc123";
            ota_hotel.ResStatus = TransactionActionType.Commit;
            ota_hotel.Version = 1 ;
            ota_hotel.TimeStamp = DateTime.Now;
            
            var pos = new SiteConnect.SourceType();
            var reqID = new SourceTypeRequestorID();

            reqID.ID = requestorID;
            reqID.Type = "22";
            pos.RequestorID = reqID;

            var bookingChannel = new SourceTypeBookingChannel();
            bookingChannel.CompanyName.Code = "EVG";
            bookingChannel.Type = "1";
            bookingChannel.Primary = true;

            pos.BookingChannel = bookingChannel;

            ota_hotel.POS[0] = pos;

            var hotelRes = new HotelReservation();

            var roomStays = new RoomStaysTypeRoomStay();
            
            roomStays.PromotionCode = "breakkie";
            RoomTypeType roomTypes = new RoomTypeType();
            roomTypes.RoomTypeCode = "ROOM1";

            roomStays.RoomTypes[0] = roomTypes;

            RatePlanType ratePlan = new RatePlanType();
            ratePlan.RatePlanCode = "RATE1";
            
            roomStays.RatePlans[0] = ratePlan;

            RoomRateType roomRate = new RoomRateType();
            roomRate.RoomTypeCode = "ROOM1";
            roomRate.RatePlanCode = "RATE1";
            roomRate.NumberOfUnits = "1";

            var rate = new RateTypeRate();
            rate.UnitMultiplier = "1";
            rate.RateTimeUnit = TimeUnitType.Day;
            rate.EffectiveDate = DateTime.Parse("2012-03-12");
            rate.ExpireDate = DateTime.Parse("2012-03-12");
            TotalType totalType = new TotalType();
            totalType.AmountBeforeTax=558;
            totalType.AmountAfterTax = 620;
            totalType.CurrencyCode="AUD";

            rate.Base = totalType;

            roomRate.Rates[0] = rate;

            var guest = new GuestCountType();
            guest.IsPerRoom = true;

            var guestCount = new GuestCountTypeGuestCount ();
            guestCount.AgeQualifyingCode = "10";
            guestCount.Count = "2";

             var guestCount1 = new GuestCountTypeGuestCount ();
            guestCount1.AgeQualifyingCode = "8";
            guestCount1.Count = "1";

            guest.GuestCount[0] = guestCount;
            guest.GuestCount[1] = guestCount1;

            roomStays.GuestCounts = guest;

            var timeSpan = new DateTimeSpanType();
            timeSpan.Start = "2012-03-12";
            timeSpan.End = "2012-03-14";

            roomStays.TimeSpan = timeSpan;

            TotalType total = new TotalType();
            total.AmountBeforeTax=558;
            total.AmountAfterTax = 620;
            total.CurrencyCode="AUD";

            roomStays.Total = total;

            var basicPro = new BasicPropertyInfoType();
            basicPro.HotelCode = "HOTEL1";
            basicPro.HotelName = "Evasion Voyage";
            roomStays.BasicPropertyInfo = basicPro;

            var resGuestRPHs = new ResGuestRPHsTypeResGuestRPH();
            resGuestRPHs.RPH = "1";
            roomStays.ResGuestRPHs[0] = resGuestRPHs;

            var comment = new CommentTypeComment();
            //comment.
            roomStays.Comments[0] = comment;

            var specialReq = new SpecialRequestTypeSpecialRequest();
            specialReq.Name = "Extra Bed";
            var specialReq1 = new SpecialRequestTypeSpecialRequest();
            specialReq1.Name = "Bedding configuration";
            
            roomStays.SpecialRequests[0] = specialReq;
            roomStays.SpecialRequests[1] = specialReq1;

            //roomStays. 
            //    ResGuests
            //hotelRes[0] = roomStays;
            
            ota_hotel.HotelReservations.HotelReservation[0].RoomStays[0] = roomStays;

            var resGuests = new ResGuestType();
            resGuests.ResGuestRPH="1";
            resGuests.ArrivalTime= DateTime.Parse("14:00:00");
            resGuests.PrimaryIndicator = true;

            var profileInfo = new ProfilesTypeProfileInfo();
            profileInfo.Profile = new ProfileType();
            profileInfo.Profile.ProfileType1 = "1";

            profileInfo.Profile.Customer = new CustomerType();
            profileInfo.Profile.Customer.PersonName[0] = new PersonNameType();
            profileInfo.Profile.Customer.PersonName[0].NamePrefix[0] = "Mr";
            profileInfo.Profile.Customer.PersonName[0].GivenName[0] = "John";
            profileInfo.Profile.Customer.PersonName[0].Surname = "Smith";

            var telePhone = new CustomerTypeTelephone();
            telePhone.PhoneNumber = "0266564100";
            profileInfo.Profile.Customer.Telephone[0] = telePhone;

            var email = new CustomerTypeEmail();
            email.Value = "test@siteminder.com.au";
            profileInfo.Profile.Customer.Email[0] = email;

            var address = new CustomerTypeAddress();
            address.AddressLine[0] = "George St";
            address.AddressLine[1] = "CBD";
            address.CityName = "Sydney";
            address.PostalCode = "2000";
            var state = new StateProvType();
            state.Value = "NSW";
            address.StateProv = state;
            var country = new CountryNameType();
            country.Code = "AU";
            country.Value = "StateProv";
            address.CountryName = country;

            profileInfo.Profile.Customer.Address[0] = address;

            resGuests.Profiles[0].Profile = profileInfo.Profile;

            ota_hotel.HotelReservations.HotelReservation[0].ResGuests[0] = resGuests;

            var resGlobalInfo = new ResGlobalInfoType();

            var resTotal = new TotalType();
            resTotal.CurrencyCode = "AUD";
            resTotal.AmountBeforeTax = 558;
            resTotal.AmountAfterTax = 620;

            resGlobalInfo.Total = resTotal;

            ota_hotel.HotelReservations.HotelReservation[0].ResGlobalInfo = resGlobalInfo;

            //securityHeader.

            //siteConnect.HotelResNotifRQ(securityHeader, ota_hotel);
            //siteConnect.HotelResNotifRQ((SecurityHeaderType)security, ota_hotel);

            return response;

        }

    }

}
