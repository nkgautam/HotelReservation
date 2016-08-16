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
using System.Xml.Linq;


namespace SiteminderWCF
{

    [ServiceContract(Namespace = "http://www.opentravel.org/OTA/2003/05")]
    [XmlSerializerFormat]         

    
    
    
    public interface IXMLData
    {

        [OperationContract]
        SiteMinderVersionResponse About();
        
        [OperationContract(Action = "http://www.siteminder.com.au/siteconnect/HotelAvailRQ")] 
        OTAResponse HotelAvailRQ(OTARequest request);

        [OperationContract(Action = "http://www.siteminder.com.au/siteconnect/HotelAvailNotifRQ", ReplyAction = "http://www.siteminder.com.au/siteconnect/HotelAvailNotifRS")] 
        OTAHotelAvailNotifRS HotelAvailNotifRQ(OTAHotelAvailPush request);

        [OperationContract(Action = "http://www.siteminder.com.au/siteconnect/HotelRateAmountNotifRQ",ReplyAction = "http://www.siteminder.com.au/siteconnect/HotelRateAmountNotifRS")] 
        OTAHotelRateAmountNotifRS HotelRateAmountNotifRQ(OTAHotelRateAmountPush request);



        OTAHotelResNotifRS HotelResNotifRQ(OTA_HotelResNotifRQ request);

    }

    [MessageContract(IsWrapped = false)]
    public class OTARequest
    {
        [MessageBodyMember(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailRQ OTA_HotelAvailRQ;

    }
   
    [MessageContract]
    public class OTA_HotelAvailRQ
    {
        [XmlAttribute]
        public string Version;
        [XmlAttribute]
        public string EchoToken;

        [XmlAttribute]
        public string TimeStamp;
       
       [XmlAttribute]
        public bool AvailRatesOnly;

       [DataMember]
       public AvailRequestSegments AvailRequestSegments;
    }

    
    [DataContract]
    public class AvailRequestSegments
    {

        [DataMember]
        public AvailRequestSegment AvailRequestSegment { get; set; }
    }

    [DataContract]
    public class AvailRequestSegment
    {

        [XmlAttribute]
        public string AvailReqType;
        [DataMember]
        public HotelSearchCriteria HotelSearchCriteria { get; set; }

    }

    [DataContract]
    public class HotelSearchCriteria
    {
        [DataMember]
        public Criterion Criterion { get; set; }

    }
    [DataContract]
    public class Criterion
    {
        [DataMember]
        public HotelRef HotelRef { get; set; }
    }

    [DataContract]
    public class HotelRef
    {
        [XmlAttribute]
        public string HotelCode;
    }

    [DataContract]
    public class SiteMinderVersionResponse
    {
        [DataMember]
        public serviceInfo ServiceResponse;
    }

    [DataContract]
    public class serviceInfo
        {
        [DataMember]
        public string ServiceName { get; set; }
        [DataMember]
        public string Version { get; set; }

        }

    //Push Response HotelAvailNotifRS
       [MessageContract(IsWrapped = false)]
    public class OTAHotelAvailNotifRS
        {
          [MessageBodyMember]
        public OTA_HotelAvailNotifRS OTA_HotelAvailNotifRS;
        
        }

    [MessageContract]
    public class OTA_HotelAvailNotifRS
        {
        [XmlAttribute]
        public string Version;
        [XmlAttribute]
        public string EchoToken;
        [XmlAttribute]
        public string TimeStamp;
        public Success Success;
      

        }

    //Push Response HotelAvailNotifRS
        [MessageContract(IsWrapped = false)]
    public class OTAHotelRateAmountNotifRS
        {
         [MessageBodyMember]
        public OTA_HotelRateAmountNotifRS OTA_HotelRateAmountNotifRS;
        
        }

    [MessageContract]
    public class OTA_HotelRateAmountNotifRS
        {
        [XmlAttribute]
        public string Version;
        [XmlAttribute]
        public string EchoToken;
        [XmlAttribute]
        public string TimeStamp;
        [MessageBodyMember]
        public Success Success;
        }

    //OtaResponse

    [MessageContract(IsWrapped=false)]
    public class OTAResponse
    {
        [MessageBodyMember(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailRS OTA_HotelAvailRS;
      

    }
    
      [MessageContract]
      public class OTA_HotelAvailRS
          {
          [XmlAttribute]
          public string Version;
          [XmlAttribute]
          public string EchoToken;
          [XmlAttribute]
          public string TimeStamp;

          [MessageBodyMember(Order=1)]
          public Success Success;
          [MessageBodyMember(Order=2)]
          public List<RoomStay> RoomStays;

          }


      [DataContract]
      public class Success
          {
          [DataMember()]
          public string status;

          }



      [DataContract]
      public class RoomStay
      {
          [DataMember()]
          public List<RoomType> RoomTypes;
          [DataMember()]
          public List<RatePlan> RatePlans;

      }
    

      [DataContract]
      public class RoomType
          {
          [XmlAttribute]
          public string RoomTypeCode;
          [DataMember()]
          public RoomDescription RoomDescription;

          }

      [DataContract]
      public class RatePlan
          {
          [XmlAttribute]
          public string RatePlanCode;
          [DataMember()]
          public RatePlanDescription RatePlanDescription;

          }

    
      [DataContract]
      public class RoomDescription
          {
          [XmlAttribute]
          public string Name;
          public string Text;

          }
    

      [DataContract]
      public class RatePlanDescription
          {
          [XmlAttribute]
          public string Name;
          public string Text;

          }

      //Get Data Part OTAHotelAvailRequest

      [MessageContract(IsWrapped = false)]
      public class OTAHotelAvailPush
          {
          [MessageBodyMember(Namespace = "http://www.opentravel.org/OTA/2003/05")]
          public OTA_HotelAvailNotifRQ OTA_HotelAvailNotifRQ;

          }
      
      [DataContract]
      public class OTA_HotelAvailNotifRQ
          {
          [XmlAttribute]
          public string Version;
       
          [XmlAttribute]
          public string TimeStamp;

          [XmlAttribute]
          public string EchoToken;

          [DataMember]
          public AvailStatusMessages AvailStatusMessages;
          }

      [DataContract]
      public class AvailStatusMessages
          {
          [XmlAttribute]
          public string HotelCode;
          [DataMember]
          public AvailStatusMessage AvailStatusMessage { get; set; }
          }

      [DataContract]
      public class AvailStatusMessage
          {

          [XmlAttribute]
          public string BookingLimit;
          [DataMember]
          public StatusApplicationControl StatusApplicationControl { get; set; }

          }

      [DataContract]
      public class StatusApplicationControl
          {

          [XmlAttribute]
          public string Start;
          [XmlAttribute]
          public string End;
          [XmlAttribute]
          public string InvTypeCode;
          [XmlAttribute]
          public string RatePlanCode;
          
          }

      //Get Data Part OTAHotelRateAmountPush

      [MessageContract(IsWrapped = false)]
      public class OTAHotelRateAmountPush
          {
          [MessageBodyMember(Namespace = "http://www.opentravel.org/OTA/2003/05")]
          public OTA_HotelRateAmountNotifRQ OTA_HotelRateAmountNotifRQ;

          }
      [DataContract]
      public class OTA_HotelRateAmountNotifRQ
          {
          [XmlAttribute]
          public string Version;

          [XmlAttribute]
          public string TimeStamp;

          [XmlAttribute]
          public string EchoToken;

                  

          [DataMember]
          public RateAmountMessages RateAmountMessages;
          }

      [DataContract]
      public class RateAmountMessages
          {
          [XmlAttribute]
          public string HotelCode;
          [DataMember]
          public RateAmountMessage RateAmountMessage { get; set; }
          }

      [DataContract]
      public class RateAmountMessage 
          {

          [DataMember]
          public StatusApplicationControl StatusApplicationControl { get; set; }
          public Rates Rates { get; set; }
          }

      [DataContract]
      public class Rates
        {
        public Rate Rate { get; set; }

        }

         [DataContract]
      public class Rate
          {

          public   BaseByGuestAmts BaseByGuestAmts { get; set; }
           public   RateDescription RateDescription { get; set; }
             
             [XmlAttribute]
          public string AgeQualifyingCode;
          [XmlAttribute]
          public string AmountAfterTax;

             }

         [DataContract]
         public class BaseByGuestAmts
             {
             public BaseByGuestAmt BaseByGuestAmt { get; set; }


             }

         [DataContract]
         public class BaseByGuestAmt
             {
          

          [XmlAttribute]
          public string AgeQualifyingCode;
          [XmlAttribute]
          public string AmountAfterTax;
          

          }


         [DataContract]
         public class RateDescription
             {
          

          [XmlAttribute]
          public string Text;
          

          }

         [MessageContract(IsWrapped = false)]
         public class OTAHotelResNotifRS
         {
             

             [MessageBodyMember]
             public OTA_HotelResNotifRS OTA_HotelResNotifRS;

         }

         [MessageContract(IsWrapped = false)]
         public class OTA_HotelResNotifRQ
         {
             [MessageBodyMember]
             public OTA_HotelResNotifRQ OTA_HotelResNotifRQ;

             

         }
         [DataContract]
         public class OTA_HotelResNotifRQ
         {
             [XmlAttribute]
             public string Version;

             [XmlAttribute]
             public string EchoToken;

             [XmlAttribute]
             public string ResStatus;

             [XmlAttribute]
             public string TimeStamp;
                      

             [DataMember]
             public POS POS;

             [DataMember]
             public Source Source;

             [DataMember]
             public RequestorID RequestorID { get; set; }

             [DataMember]
             public BookingChannel BookingChannel { get; set; }
             [DataMember]
             public HotelReservations HotelReservations { get; set; }
         }

         [DataContract]
         public class HotelReservations
         {
             [DataMember]
             public HotelReservation HotelReservation { get; set; }
         }

         [DataContract]
         public class HotelReservation
         {
             [XmlAttribute]
             public string CreateDateTime;

             [DataMember]
             public UniqueID UniqueID { get; set; }
             

             [DataMember]
             public RoomStays RoomStays { get; set; }

             [DataMember]
             public ResGuests ResGuests { get; set; }

             [DataMember]
             public ResGlobalInfo ResGlobalInfo { get; set; }
            
         }

         [DataContract]
         public class ResGlobalInfo
         {
             [DataMember]
             public Total Total { get; set; }
             [DataMember]
             public Guarantee Guarantee { get; set; }
             [DataMember]
             public DepositPayments DepositPayments { get; set; }
             [DataMember]
             public Profiles Profiles { get; set; }
             [DataMember]
             public HotelReservationIDs HotelReservationIDs { get; set; }

         }

         [DataContract]
         public class HotelReservationIDs
         {
             [DataMember]
             public HotelReservationID HotelReservationID { get; set; }

         }

         [DataContract]
         public class HotelReservationID
         {
             [XmlAttribute]
             public string ResID_Type;
             [XmlAttribute]
             public string ResID_Value;
            
         }

         [DataContract]
         public class DepositPayments
         {
             [DataMember]
             public GuaranteePayment GuaranteePayment { get; set; }

         }

         [DataContract]
         public class GuaranteePayment
         {
             [DataMember]
             public AcceptedPayments AcceptedPayments { get; set; }

         }

         [DataContract]
         public class AcceptedPayments
         {
             [DataMember]
             public AcceptedPayment AcceptedPayment { get; set; }

         }

         [DataContract]
         public class AcceptedPayment
         {
             [DataMember]
             public PaymentCard PaymentCard { get; set; }

         }

         [DataContract]
         public class Guarantee
         {
             [DataMember]
             public GuaranteesAccepted GuaranteesAccepted { get; set; }

         }
         [DataContract]
         public class GuaranteesAccepted
         {
             [DataMember]
             public GuaranteeAccepted GuaraGuaranteeAcceptednteesAccepted { get; set; }

         }
    
        [DataContract]
         public class GuaranteeAccepted
         {
             [DataMember]
            public PaymentCard PaymentCard { get; set; }

         }
        [DataContract]
        public class PaymentCard
        {
            [XmlAttribute]
            public string CardNumber;
            [XmlAttribute]
            public string CardType;
            [XmlAttribute]
            public string ExpireDate;
            [XmlAttribute]
            public string SeriesCode;
            [XmlAttribute]
            public string CardCode;
            [DataMember]
            public CardHolderName CardHolderName { get; set; }

        }
        [DataContract]
        public class CardHolderName
        {
            [XmlAttribute]
            public string Name;
            public string Text;

        }

         [DataContract]
         public class ResGuests
         {
             [DataMember]
             public ResGuest ResGuest { get; set; }

         }

         [DataContract]
         public class ResGuest
         {
             [XmlAttribute]
             public string ResGuestRPH;
             [XmlAttribute]
             public string ArrivalTime;
             [XmlAttribute]
             public string PrimaryIndicator;
             [DataMember]
             public Profiles Profiles { get; set; }

         }

         [DataContract]
         public class Profiles
         {
             [DataMember]
             public ProfileInfo ProfileInfo { get; set; }

         }

         [DataContract]
         public class ProfileInfo
         {
             [DataMember]
             public Profile Profile { get; set; }

         }

         [DataContract]
         public class Profile
         {
             [XmlAttribute]
             public string ProfileType;
             [DataMember]
             public Customer Customer { get; set; }

         }

         [DataContract]
         public class Customer
         {
             [DataMember]
             public PersonName PersonName;

             [DataMember]
             public Telephone Telephone;

             [DataMember]
             public Email Email;

             [DataMember]
             public Address Address;

         }

         [DataContract]
         public class Address
         {
             [DataMember]
             public AddressLine AddressLine { get; set; }

             [DataMember]
             public CityName CityName { get; set; }

             [DataMember]
             public PostalCode PostalCode { get; set; }

             [DataMember]
             public StateProv StateProv { get; set; }

             [DataMember]
             public CountryName CountryName { get; set; }

         }

         [DataContract]
         public class CountryName
         {
             [XmlAttribute]
             public string Code;
             public string Name;
             public string Text;

         }

         [DataContract]
         public class AddressLine
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }
         [DataContract]
         public class CityName
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }
         [DataContract]
         public class PostalCode
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }
         [DataContract]
         public class StateProv
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }
         [DataContract]
         public class Telephone
         {
             [XmlAttribute]
             public string PhoneNumber;

         }

         [DataContract]
         public class PersonName
         {
             [DataMember]
             public NamePrefix NamePrefix { get; set; }

             [DataMember]
             public GivenName GivenName { get; set; }

             [DataMember]
             public Surname Surname { get; set; }

         }

         [DataContract]
         public class Email
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }

         [DataContract]
         public class NamePrefix
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }
         [DataContract]
         public class GivenName
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }
         [DataContract]
         public class Surname
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }

         [DataContract]
         public class UniqueID
         {
             [XmlAttribute]
             public string Type;

             [XmlAttribute]
             public string ID;

         }

         [DataContract]
         public class RoomStays
         {
             [DataMember]
             public RoomStay RoomStay { get; set; }

         }

         //[DataContract]
         //public class RoomStay
         //{
         //    [XmlAttribute]
         //    public string PromotionCode;
         //    [DataMember()]
         //    public RoomTypes RoomTypes;
         //    [DataMember()]
         //    public RatePlans RatePlans;
         //    [DataMember]
         //    public RoomRates RoomRates;
         //    [DataMember]
         //    public GuestCounts GuestCounts;
         //    [DataMember]
         //    public TimeSpan TimeSpan;
         //    [DataMember]
         //    public Total Total;
         //    [DataMember]
         //    public BasicPropertyInfo BasicPropertyInfo;
         //    [DataMember]
         //    public ResGuestRPHs ResGuestRPHs;
         //    [DataMember]
         //    public Comments Comments;
         //    [DataMember]
         //    public SpecialRequests SpecialRequests;

         //}

         [DataContract]
         public class SpecialRequests
         {
             
             [DataMember]
             public SpecialRequest SpecialRequest { get; set; }

         }

         [DataContract]
         public class SpecialRequest
         {
             [XmlAttribute]
             public string Name;
             //[DataMember]
             //public SpecialRequest SpecialRequest;

         }

         [DataContract]
         public class Total
         {
             [XmlAttribute]
             public string AmountBeforeTax;
             [XmlAttribute]
             public string AmountAfterTax;
             [XmlAttribute]
             public string CurrencyCode;
             [DataMember]
             public Taxes Taxes { get; set; }

         }

         [DataContract]
         public class Taxes
         {
             [XmlAttribute]
             public string Amount;
             [XmlAttribute]
             public string CurrencyCode;

         }

         [DataContract]
         public class BasicPropertyInfo
         {
             [XmlAttribute]
             public string HotelCode;
             [XmlAttribute]
             public string HotelName;

         }

         [DataContract]
         public class ResGuestRPHs
         {
             [DataMember]
             public ResGuestRPH ResGuestRPH { get; set; }

         }

         [DataContract]
         public class ResGuestRPH
         {
             [XmlAttribute]
             public string RPH;

         }

         [DataContract]
         public class Comments
         {
             [DataMember]
             public Comment Comment { get; set; }

         }

         [DataContract]
         public class Comment
         {
             [XmlAttribute]
             public string Name;
             public string Text;

         }

         [DataContract]
         public class GuestCounts
         {
             [XmlAttribute]
             public string IsPerRoom;
             [DataMember]
             public GuestCount GuestCount { get; set; }

         }

         [DataContract]
         public class GuestCount
         {
             [XmlAttribute]
             public string AgeQualifyingCode;
             [XmlAttribute]
             public string Count;

         }
         [DataContract]
         public class RoomRates
         {
             [DataMember]
             public RoomRate RoomRate { get; set; }

         }

         [DataContract]
         public class RoomRate
         {
             [XmlAttribute]
             public string RoomTypeCode;
             [XmlAttribute]
             public string RatePlanCode;
             [XmlAttribute]
             public string NumberOfUnits;
             [DataMember]
             public Rates Rates { get; set; }

         }


         [DataContract]
         public class RoomTypes
         {
             [DataMember]
             public RoomType RoomType;

         }

         //[DataContract]
         //public class RoomType
         //{
         //    [XmlAttribute]
         //    public string RoomTypeCode;
         //    [DataMember]
         //    public RoomDescription RoomDescription;

         //}

         [DataContract]
         public class RatePlans
         {

             public RatePlan RatePlan { get; set; }

         }
        
         [DataContract]
         public class BookingChannel
         {
             [XmlAttribute]
             public bool Primary;

             [XmlAttribute]
             public string Type;

             [DataMember]
             public CompanyName CompanyName { get; set; }
         }

         [DataContract]
         public class CompanyName
         {
             [XmlAttribute]
             public string Code;
            
         }

         [DataContract]
         public class RequestorID
         {
             [XmlAttribute]
             public string Type;

             [XmlAttribute]
             public string ID;
         }

         [DataContract]
         public class Source
         {

         }
         [DataContract]
         public class POS
         {

         }

    
         [DataContract]
         public class OTA_HotelResNotifRS
         {
             [XmlAttribute]
             public string Version;

             [XmlAttribute]
             public string TimeStamp;

             [XmlAttribute]
             public string EchoToken;

             [DataMember]
             public Success Success;

             [DataMember]
             public HotelReservations HotelReservations;
         }

}
