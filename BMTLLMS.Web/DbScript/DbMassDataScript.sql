USE [master]
GO
/****** Object:  Database [DbMassData]    Script Date: 9/24/2023 8:04:00 PM ******/
Use  [DbMassData]

GO
CREATE TABLE [dbo].[Attribute_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[AttributeTypeID] [int] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Attribute_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attribute_Type_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute_Type_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Attribute_Type_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calibration_Frequency_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calibration_Frequency_T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[MachineID] [int] NULL,
	[CorrectionFactor] [decimal](18, 5) NOT NULL,
	[MeasurementUnitID] [int] NULL,
	[EffectiveDate] [datetime] NULL,
	[CalibrationFrequencyInDays] [int] NULL,
	[CalibrationFrequencyInTestNumber] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Calibration_Frequency_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[Logo] [varchar](500) NULL,
	[WebsiteAddress] [varchar](500) NULL,
	[EmailAddress] [varchar](500) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[PhysicalAddress] [varchar](500) NULL,
	[Fax] [varchar](500) NULL,
	[LocationLat] [varchar](500) NULL,
	[LocationLng] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Company_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[ShortName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Currency_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NOT NULL,
	[ContactPersonName] [varchar](500) NULL,
	[ContactEmail] [varchar](500) NULL,
	[ContactAddress] [varchar](500) NULL,
	[ContactPhone] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Customer_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deliver_Report_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliver_Report_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[OrderID] [bigint] NULL,
	[DeliveryDateTime] [datetime] NULL,
	[DeliveredByID] [bigint] NULL,
	[DeliverTo] [varchar](500) NULL,
	[DeliverNote] [varchar](500) NULL,
	[ReturnNote] [varchar](500) NULL,
	[IsReturn] [bit] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Deliver_Report_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocUpload_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocUpload_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[TransactionTypeAttributeID] [bigint] NULL,
	[TransactionID] [bigint] NULL,
	[DocName] [varchar](200) NULL,
	[DocExtension] [varchar](50) NULL,
	[FileName] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_DocUpload_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogT]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorMsg] [varchar](200) NULL,
	[SpName] [varchar](200) NULL,
	[ErrorMsgCode] [int] NULL,
	[ErrorMsgFull] [varchar](max) NULL,
	[ErrorTime] [datetime] NULL,
	[Controller] [varchar](200) NULL,
	[UserId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machine_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[MachineTypeAttributeID] [bigint] NULL,
	[Name] [varchar](500) NULL,
	[JawType] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Machine_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurement_Unit_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurement_Unit_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[Description] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Measurement_Unit_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Child_Sample_Condition_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Child_Sample_Condition_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SampleID] [bigint] NULL,
	[SampleConditionID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Order_Child_Sample_Condition_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Child_Sample_Specification_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Child_Sample_Specification_T](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SampleID] [bigint] NOT NULL,
	[Specification_ID] [bigint] NOT NULL,
	[Specification_Value] [decimal](18, 3) NOT NULL,
	[Creator] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifire] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Order_Child_Sample_Specification_T] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Child_Sample_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Child_Sample_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[ParentID] [bigint] NULL,
	[SampleTypeID] [bigint] NULL,
	[SampleDescription] [varchar](500) NULL,
	[FirstReceiveDateTime] [datetime] NULL,
	[LastReceiveDateTime] [datetime] NULL,
	[IsReceiveComplete] [bit] NULL,
	[ProducerID] [bigint] NULL,
	[LotNo] [varchar](50) NULL,
	[ReqNumberOfSamplePcs] [int] NULL,
	[MeasurementUnitID] [bigint] NULL,
	[QtyPreSample] [decimal](18, 3) NULL,
	[RetenedSampleID] [nchar](10) NULL,
	[Note] [varchar](300) NULL,
	[IsSentForProcessing] [bit] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NULL,
	[CreationDate] [datetime] NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Order_Child_Sample_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Child_Test_Standard_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Child_Test_Standard_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[SampleID] [bigint] NULL,
	[TestStandardID] [bigint] NULL,
	[QtyNumber] [bigint] NULL,
	[UnitPrice] [decimal](18, 5) NULL,
	[Note] [varchar](500) NULL,
	[DeliveryDate] [date] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
	[AssignedTecnicianID] [int] NULL,
	[AssignedToTecnicianDate] [datetime] NULL,
 CONSTRAINT [PK_Order_Child_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Parent_t]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Parent_t](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[CustomerID] [bigint] NULL,
	[ContactName] [varchar](500) NULL,
	[ContactEmail] [varchar](500) NULL,
	[ContactMobile] [varchar](50) NULL,
	[ContactAddress] [varchar](500) NULL,
	[ProjectID] [bigint] NULL,
	[OrderDate] [datetime] NULL,
	[IsPaid] [bit] NULL,
	[LastPaymentDate] [datetime] NULL,
	[Description] [varchar](500) NULL,
	[DiscountAmount] [decimal](18, 3) NULL,
	[DeliveryTypeAttributeID] [bigint] NULL,
	[IsCancel] [bit] NULL,
	[PaymentMode] [varchar](500) NULL,
	[CurrencyCode] [bigint] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Order_Parent_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Method_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Method_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Payment_Method_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Receive_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Receive_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[OrderID] [bigint] NULL,
	[DateTime] [datetime] NULL,
	[Amount] [decimal](18, 5) NULL,
	[PaymentMode] [varchar](500) NULL,
	[PaymentRefNo] [varchar](500) NULL,
	[Note] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Payment_Receive_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceAgreementChild_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceAgreementChild_T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[ParentID] [int] NOT NULL,
	[TestStandardID] [int] NOT NULL,
	[SampleTypeID] [int] NOT NULL,
	[RegularPrice] [decimal](18, 3) NOT NULL,
	[ExpressPrice] [decimal](18, 3) NOT NULL,
	[CurrencyID] [bigint] NULL,
	[Note] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[Creator] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_AgreementChildT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceAgreementParent_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceAgreementParent_T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[CustomerID] [int] NOT NULL,
	[AgreementDate] [date] NOT NULL,
	[EffectiveDateFrom] [date] NOT NULL,
	[EffectiveDateTo] [date] NOT NULL,
	[Description] [varchar](max) NULL,
	[Signee_id] [varchar](50) NULL,
	[CustomerSideSigneeName] [varchar](100) NULL,
	[CustomerSideSigneeDesignation] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[Creator] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_PriceAgreementParentT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producer_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](200) NULL,
	[Address] [varchar](100) NULL,
	[ContactPerson] [varchar](200) NULL,
	[Phone] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Producer_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[ContactPerson] [varchar](500) NULL,
	[ContactPhone] [varchar](50) NULL,
	[ContactEmail] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Project_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_Category_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_Category_T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](200) NOT NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_Category_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_Physical_Condition_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_Physical_Condition_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[Description] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_Condition_Attribute_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_Receive_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_Receive_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SampleID] [bigint] NOT NULL,
	[NumberOfSamplePcs] [int] NOT NULL,
	[QtyPerSample] [decimal](18, 3) NOT NULL,
	[ReceivedByID] [int] NOT NULL,
	[ReceivedDateTime] [datetime] NOT NULL,
	[RetenedSampleID] [nchar](10) NULL,
	[Note] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[Creator] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_Receive_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_Stock_ledger_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_Stock_ledger_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[SampleID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[ProductID] [bigint] NULL,
	[SpecificationID] [bigint] NULL,
	[TransactionType] [varchar](500) NULL,
	[TransactionID] [bigint] NULL,
	[SectionID] [bigint] NULL,
	[InQty] [bigint] NULL,
	[OutQty] [bigint] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_Stock_ledger_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_stock_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_stock_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[SampleID] [bigint] NULL,
	[SpecificationID] [bigint] NULL,
	[SectionID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[ProductID] [bigint] NULL,
	[InQty] [bigint] NULL,
	[OutQty] [bigint] NULL,
 CONSTRAINT [PK_Sample_stock_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_Transfer_Child_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_Transfer_Child_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[ParentID] [bigint] NULL,
	[SampleID] [bigint] NULL,
	[Quantity] [decimal](18, 3) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [bigint] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_Transfer_Child_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_Transfer_Parent_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_Transfer_Parent_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[DateTime] [datetime] NULL,
	[TransferByID] [bigint] NULL,
	[TransferFromSectionID] [int] NULL,
	[TransferToSectionID] [int] NULL,
	[IsReceived] [bit] NULL,
	[IsReturned] [bit] NULL,
	[ReceivedByID] [bigint] NULL,
	[ReturnedByID] [bigint] NULL,
	[ReceiveDateTime] [datetime] NULL,
	[ReturnDateTime] [datetime] NULL,
	[ReturnNote] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[ReturnHistoryWithNote] [varchar](max) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_Transfer_Parent_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample_type_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample_type_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[SampleCategoryID] [int] NULL,
	[Name] [varchar](500) NULL,
	[Description] [varchar](500) NULL,
	[DefaultMeasurementUnitId] [bigint] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Sample_type_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SampleType_VS_Specification_Type_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleType_VS_Specification_Type_T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[SampleTypeID] [int] NULL,
	[SpecificationHeadID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_SampleType_VS_Specification_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SampleType_VS_TestStandard_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleType_VS_TestStandard_T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[SampleTypeID] [int] NULL,
	[TestStandardID] [int] NULL,
	[ReqNumberOfSamplePcs] [int] NOT NULL,
	[QtyPerSample] [decimal](18, 3) NOT NULL,
	[ReqSampleDescription] [varchar](200) NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_SampleType_VS_TestStandard_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](200) NULL,
	[CompanyID] [int] NULL,
	[isActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifire] [int] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_SectionTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specification_Head_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specification_Head_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](150) NOT NULL,
	[MeasurementUnitID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Specification_Head_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specimen_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specimen_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SpecimenCode] [varchar](500) NULL,
	[OrderChildTestStandardID] [bigint] NULL,
	[NoOfspecimen] [bigint] NULL,
	[RequiredSampleQty] [decimal](18, 3) NULL,
	[SpecimenDescription] [varchar](200) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_SpecimenParent_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Child_CharacteristicsOpening_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Child_CharacteristicsOpening_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[SpecimenWt] [decimal](18, 3) NULL,
	[ReceiverSieveWt] [decimal](18, 3) NULL,
	[ReceiverSieveWtWithBeads] [decimal](18, 3) NULL,
	[InitialBeadsWt] [decimal](18, 3) NULL,
	[SpecimenWtWithBeads] [decimal](18, 3) NULL,
	[SpecimenGraphImg] [varchar](500) NULL,
	[StartMassForSieve] [varchar](500) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Child_CharacteristicsOpening_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Child_MassPerUnitArea_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Child_MassPerUnitArea_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[Weight] [decimal](18, 3) NULL,
	[SpecimenArea] [decimal](18, 3) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Child_MassPerUnitArea_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Child_StaticPuncture_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Child_StaticPuncture_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[ReadingSL] [varchar](500) NULL,
	[ForceNewton] [varchar](500) NULL,
	[Displacement] [varchar](500) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Child_StaticPuncture_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Child_Tansile_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Child_Tansile_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[SpecimenSL] [bigint] NULL,
	[StrengthKnPerM] [decimal](18, 3) NULL,
	[ElongationPercent] [decimal](18, 3) NULL,
	[DirectionTypeID] [bigint] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Child_Tansile_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Child_Thickness_Test_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Child_Thickness_Test_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[SpecimenSL] [bigint] NULL,
	[ReadingSL] [bigint] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Child_Thickness_Test_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Child_WaterPermeability_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Child_WaterPermeability_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[SpecimenID] [bigint] NULL,
	[SpecimenSL] [bigint] NULL,
	[SpecimenWt] [decimal](18, 3) NULL,
	[TimeSec] [decimal](18, 3) NULL,
	[PassedWaterVolume] [decimal](18, 3) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Child_WaterPermeability_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Grand_Child_CharacteristicsOpening_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Grand_Child_CharacteristicsOpening_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ChildID] [bigint] NULL,
	[Sievemicron] [varchar](50) NULL,
	[SieveWt] [decimal](18, 3) NULL,
	[SieveWtWithRetainedBeads] [decimal](18, 3) NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Grand_Child_CharacteristicsOpening_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TD_Parent_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TD_Parent_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderChildTestStandardID] [bigint] NULL,
	[TestDateTimeFrom] [datetime] NULL,
	[TestDateTimeTo] [datetime] NULL,
	[TechnicianID] [bigint] NULL,
	[VerificationStatusAttributeID] [bigint] NULL,
	[VerifiedByID] [bigint] NULL,
	[VerificationNote] [varchar](500) NULL,
	[IsPreloaded] [bit] NULL,
	[IsCanceled] [bit] NULL,
	[CanceledBy] [varchar](500) NULL,
	[CancelDateTime] [datetime] NULL,
	[CancelNote] [varchar](500) NULL,
	[TestNote] [varchar](500) NULL,
	[MachineID] [bigint] NULL,
	[SievingArea] [decimal](18, 3) NULL,
	[SievingDiameter] [decimal](18, 3) NULL,
	[TemparatureFrom] [decimal](18, 2) NULL,
	[TemparatureTo] [decimal](18, 2) NULL,
	[WaterTemperature] [decimal](18, 2) NULL,
	[CorrectionFactor] [decimal](18, 4) NULL,
	[RelativeHumidityFrom] [decimal](18, 2) NULL,
	[RelativeHumidityTo] [decimal](18, 2) NULL,
	[SpecimenConditioning] [varchar](500) NULL,
	[ExposedSpecimenArea] [decimal](18, 3) NULL,
	[VerificationHistory] [varchar](500) NULL,
	[VerificationDateTime] [datetime] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_TD_Parent_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Assign_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Assign_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderChildTestStanderdID] [bigint] NULL,
	[UserID] [int] NOT NULL,
	[Creator] [bigint] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Test_Assign_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Name_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Name_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[TestGroupAttributeID] [bigint] NULL,
	[Name] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Test_Standard_Parent_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Standard_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Standard_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[TestNameID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Test_t] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_StandardVSMachine_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_StandardVSMachine_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[TestStandardID] [bigint] NULL,
	[MachineID] [bigint] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Test_StandardVSMachine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_StandardWise_Price_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_StandardWise_Price_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[TestStandardID] [bigint] NULL,
	[CurrencyID] [bigint] NULL,
	[RegularDeliveryDays] [int] NULL,
	[ExpressDeliveryDays] [int] NULL,
	[RegularPrice] [decimal](18, 2) NOT NULL,
	[ExpressPrice] [decimal](18, 2) NOT NULL,
	[EffectiveDateFrom] [date] NOT NULL,
	[EffectiveDateTo] [date] NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [bigint] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Test_StandardWise_Price_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_T]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_T](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GID] [uniqueidentifier] NULL,
	[Name] [varchar](500) NULL,
	[UserName] [varchar](500) NULL,
	[Email] [varchar](500) NULL,
	[Password] [varchar](500) NULL,
	[Designation] [varchar](500) NULL,
	[UserTypeAttributeID] [int] NULL,
	[UserSectionID] [int] NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_User_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order_Child_Sample_Condition_T]  WITH CHECK ADD  CONSTRAINT [FK_Order_Child_Sample_Condition_T_Order_Child_Sample_T] FOREIGN KEY([SampleID])
REFERENCES [dbo].[Order_Child_Sample_T] ([ID])
GO
ALTER TABLE [dbo].[Order_Child_Sample_Condition_T] CHECK CONSTRAINT [FK_Order_Child_Sample_Condition_T_Order_Child_Sample_T]
GO
ALTER TABLE [dbo].[Order_Child_Sample_T]  WITH CHECK ADD  CONSTRAINT [FK_Order_Child_Sample_T_Order_Parent_t] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Order_Parent_t] ([ID])
GO
ALTER TABLE [dbo].[Order_Child_Sample_T] CHECK CONSTRAINT [FK_Order_Child_Sample_T_Order_Parent_t]
GO
ALTER TABLE [dbo].[Order_Child_Test_Standard_T]  WITH CHECK ADD  CONSTRAINT [FK_Order_Child_Test_Standard_T_Order_Child_Sample_T] FOREIGN KEY([SampleID])
REFERENCES [dbo].[Order_Child_Sample_T] ([ID])
GO
ALTER TABLE [dbo].[Order_Child_Test_Standard_T] CHECK CONSTRAINT [FK_Order_Child_Test_Standard_T_Order_Child_Sample_T]
GO
ALTER TABLE [dbo].[Sample_Receive_T]  WITH CHECK ADD  CONSTRAINT [FK_Sample_Receive_T_Order_Child_Sample_T] FOREIGN KEY([SampleID])
REFERENCES [dbo].[Order_Child_Sample_T] ([ID])
GO
ALTER TABLE [dbo].[Sample_Receive_T] CHECK CONSTRAINT [FK_Sample_Receive_T_Order_Child_Sample_T]
GO
ALTER TABLE [dbo].[Sample_type_T]  WITH CHECK ADD  CONSTRAINT [FK_Sample_type_T_Sample_Category_T] FOREIGN KEY([SampleCategoryID])
REFERENCES [dbo].[Sample_Category_T] ([ID])
GO
ALTER TABLE [dbo].[Sample_type_T] CHECK CONSTRAINT [FK_Sample_type_T_Sample_Category_T]
GO
/****** Object:  StoredProcedure [dbo].[AuthenticateUserData_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[AuthenticateUserData_SP]
@Username nvarchar(50),
@Password nvarchar(150)

AS
BEGIN
	SELECT * FROM User_T WHERE Username=@Username and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[ErrorLog]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---- ErrorLog 'establishment','Test_sp','404','111111111111111111111dddddddddddddddddddddhhhhhhhhhhhhhhhhhhhhhhhaaaaaaaaaaaaaaaaaolahdladhaslsdddddd','Home',1
CREATE PROCEDURE [dbo].[ErrorLog]
@ErrorMsg VARCHAR (max),
@SpName VARCHAR (100),
@ErrorMsgCode VARCHAR (10),
@ErrorMsgFull VARCHAR (MAX),
@Controller VARCHAR (100),
@UserId int

as
BEGIN
INSERT INTO [dbo].[ErrorLogT]
           ([ErrorMsg],[SpName],[ErrorMsgCode],[ErrorMsgFull],[ErrorTime],[Controller],[UserId])
     VALUES
           (@ErrorMsg,@SpName,@ErrorMsgCode,@ErrorMsgFull,GETDATE(),@Controller,@UserId)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttribute_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAttribute_SP]
(
	@ID INT = 0,
	@TypeId INT = 0
)
As 
Begin 
	Select t.ID AS ID,t.Name AS Name,t.AttributeTypeID As AttributeTypeID,tpe.Name As TypeName,t.IsActive from Attribute_T  t 
	inner join Attribute_Type_T tpe on t.AttributeTypeID = tpe.ID
	where (t.ID=@ID or @ID=0) and (t.AttributeTypeID=@TypeId or @TypeId=0)
End
GO
/****** Object:  StoredProcedure [dbo].[GetAttributeType_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAttributeType_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select t.ID AS TypeId,t.Name AS AttributeTypeName,t.IsActive from Attribute_Type_T  t 
	where t.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetByIdOrder_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetByIdOrder_SP]  
(
	--@GID nvarchar(max) 
	@GID uniqueidentifier 

)
As 
Begin 
	SELECT 
	p.ID
	,
	p.GID
	,p.CustomerID 
	,p.ContactName , p.ContactEmail, p.ContactMobile,	p.ContactAddress ,	p.ProjectID
	,p.OrderDate,	p.IsPaid,	p.LastPaymentDate,	p.Description,	p.IsCancel,	p.PaymentMode
	,p.CurrencyCode,p.Modifier,	p.ModificationDate,c.SampleTypeID ,st.Name as SampleTypeName,st.SampleCategoryID, sc.Name as SampleCategoryName 
	,c.ProducerID,	c.LotNo,c.ReqNumberOfSamplePcs,
    c.MeasurementUnitID,	c.QtyPreSample,	c.RetenedSampleID,	c.IsSentForProcessing,
	ts.SampleID,	ts.TestStandardID,t.Name as TestStandardName, t.TestNameID,tn.Name as TestName ,	ts.QtyNumber,	ts.UnitPrice,	ts.Note, ts.DeliveryDate
	FROM  Order_Parent_T as P inner join Order_Child_Sample_T as C on p.ID=c.ParentID inner join Order_Child_Test_Standard_T as TS
	on ts.SampleID=c.ID inner join  Sample_type_T as st on c.SampleTypeID = st.ID 
	inner join Sample_Category_T as sc on st.SampleCategoryID = sc.ID
	inner join Test_Standard_T as t on ts.TestStandardID = t.ID
	inner join Test_Name_T as tn on t.TestNameID = tn.ID
	where p.GID=@GID

End
GO
/****** Object:  StoredProcedure [dbo].[GetCalibrationFrequency_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetCalibrationFrequency_SP 
CREATE Procedure [dbo].[GetCalibrationFrequency_SP]
(
	@ID INT = 0
)
As 
Begin 
	Select c.ID ,MachineID,CorrectionFactor,MeasurementUnitID,EffectiveDate,
	CalibrationFrequencyInDays,CalibrationFrequencyInTestNumber,mch.MachineTypeAttributeID,
	mch.Name as MachineName,mch.JawType,meas.Name As MeasurementUnitName,c.IsActive
	from Calibration_Frequency_T  c  
	inner join Machine_T mch on c.MachineID = mch.ID
	inner join Measurement_Unit_T meas on c.MeasurementUnitID = meas.ID
	where c.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetCompany_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----Exec GetCompany_SP 
CREATE Procedure [dbo].[GetCompany_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select c.ID AS ID,c.Name AS Name,c.Logo As Logo,c.WebsiteAddress As WebsiteAddress,c.EmailAddress As EmailAddress,c.PhoneNumber As PhoneNumber,c.PhysicalAddress As PhysicalAddress,c.Fax As Fax,c.LocationLat As LocationLat,c.LocationLng As LocationLng,c.IsActive from Company_T  c  where c.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetCurrency_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetCurrency_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select c.ID AS ID,c.Name AS Name,c.ShortName,c.IsActive from Currency_T  c  where c.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetCustomer_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----EXEC [dbo].[GetCustomer_SP] 1
CREATE Procedure [dbo].[GetCustomer_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select c.ID AS ID,c.Name AS Name,c.ContactPersonName,c.ContactEmail,c.ContactAddress,c.ContactPhone,c.IsActive  from Customer_T  c  where c.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetDocUpload_T_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetDocUpload_T_SP 1
CREATE Procedure [dbo].[GetDocUpload_T_SP]
(
	@ID INT = 0
)
As 
Begin 
	Select t.ID AS ID,t.TransactionTypeAttributeID,t.TransactionID,t.DocName,t.DocExtension,t.FileName,
	att.Name As AttributeName,att.AttributeTypeID,spt.SampleCategoryID,spt.Name As SampleTypeName,
	spt.Description As SampleTypeDescription,t.IsActive
	from DocUpload_T  t 
	inner join Attribute_T att on t.TransactionTypeAttributeID = att.ID
	inner join Sample_type_T spt on t.TransactionID = spt.ID
	where t.ID=@ID or @ID=0
End

GO
/****** Object:  StoredProcedure [dbo].[GetMachine_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetMachine_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select m.ID AS ID,m.Name AS Name,m.JawType As JawType,m.MachineTypeAttributeID As MachineTypeAttributeID,att.Name As AttributeName,m.IsActive from Machine_T  m
	inner join dbo.Attribute_T att on m.MachineTypeAttributeID = att.ID 
	inner join Attribute_Type_T as AT on at.ID=att.AttributeTypeID
	where m.ID=@ID or @ID=0  and AT.ID=2
End
GO
/****** Object:  StoredProcedure [dbo].[GetMeasurementUnit_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---EXEC [dbo].[GetMeasurementUnit_SP] 0
CREATE Procedure [dbo].[GetMeasurementUnit_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select u.ID AS ID,u.Name AS Name,u.Description AS Description,u.IsActive from Measurement_Unit_T u  where u.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDetailsList]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---- GetOrderDetailsList 72,'2023-09-09','2023-09-09',1,0,'2023-09-06','2023-09-09'
---- GetOrderDetailsList 0,'2023-09-09','2023-09-19',1,-1,'',''
CREATE Procedure [dbo].[GetOrderDetailsList] 
(
    @OrderRefNo bigint = 0,
    @OrderDateFrom nvarchar(50)='',
	@OrderDateTo nvarchar(50)='',
	@CustomerID bigint = 0,
	@StatusID bigint = -1,
	@DeliveryDateFrom nvarchar(50)='',
	@DeliveryDateTo nvarchar(50)=''
)
As 
BEGIN 
   Select ord.ID As ID,ord.OrderDate,ord.CustomerID,
   cust.Name As CustomerName,COUNT(ordtestStd.ID) As TestStandardCount,
   SampleT.Name as SampleType,SampleT.ID As SampleTypeID,ordch.ID As SampleID,SampleCategory.Name as SampleCategory,
   min(SPVSTS.ReqNumberOfSamplePcs) as ReqNumberOfSamplePcs,min(SPVSTS.QtyPerSample) as QtyPerSample,
   measureUnit.Name As MeasurementUnitName,
   case when 
   ISNULL(SampleReceive.SampleID,0)=0 then 0 else 1 end as IsReceived,
   STUFF((SELECT ', ' + TS.Name  	FROM Order_Child_Test_Standard_T OrderTestStandard inner join  	[Test_Standard_T] as TS on OrderTestStandard.[TestStandardID]=TS.ID 	WHERE  OrderTestStandard.sampleid=ordch.id 	FOR XML PATH('')), 1, 1, '') as Description 
	into #TempT
   from Order_Parent_t ord
   inner join Order_Child_Sample_T ordch on ord.ID = ordch.ParentID
   inner join Order_Child_Test_Standard_T ordtestStd on ordch.ID = ordtestStd.SampleID
   inner join Customer_T cust on ord.CustomerID = cust.ID
   inner join SampleType_VS_TestStandard_T as SPVSTS on SPVSTS.TestStandardID=ordtestStd.TestStandardID and ordch.SampleTypeID=SPVSTS.SampleTypeID
   inner join [Sample_type_T] as SampleT on SampleT.ID=SPVSTS.SampleTypeID    inner join Sample_Category_T as SampleCategory on SampleCategory.ID=SampleT.[SampleCategoryID]
   inner join Measurement_Unit_T as measureUnit on SampleT.DefaultMeasurementUnitId = measureUnit.ID
   left join Sample_Receive_T as SampleReceive on   ordch.ID=SampleReceive.SampleID
   where (ord.ID = @OrderRefNo or @OrderRefNo = 0) and (ord.CustomerID=@CustomerID or @CustomerID = 0)
   and (( CONVERT(date, ord.OrderDate) between CONVERT(date, @OrderDateFrom) and CONVERT(date, @OrderDateTo)) or @OrderDateFrom = '' )
   and (( CONVERT(date, ordtestStd.DeliveryDate) between CONVERT(date,@DeliveryDateFrom) and CONVERT(date, @DeliveryDateTo)) or @DeliveryDateFrom ='')
   
   group by ord.ID , ord.OrderDate,ord.CustomerID,cust.Name,ordch.id,SampleT.Name,ordch.ID,SampleCategory.Name,measureUnit.Name,SampleT.ID,SampleReceive.SampleID

   select * from #TempT as t where (t.IsReceived=@StatusID or @StatusID=-1)
   drop table #TempT
   
END

GO
/****** Object:  StoredProcedure [dbo].[GetPriceAgreement_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetPriceAgreement_SP]
(
    @ID bigint
)
AS 
BEGIN
    Select prent.ID,prent.CustomerID,prent.AgreementDate,prent.EffectiveDateFrom,prent.EffectiveDateTo,
	prent.Description,prent.Signee_id,prent.CustomerSideSigneeName,prent.CustomerSideSigneeDesignation,
	prent.IsActive,child.ID As ChildID,child.ParentID,child.TestStandardID,child.SampleTypeID,child.RegularPrice,
	child.ExpressPrice,child.CurrencyID,child.Note
	from PriceAgreementParent_T prent 
	inner join PriceAgreementChild_T child on prent.ID = child.ParentID
	Where prent.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetPriceAgreementChild]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Exec GetPriceAgreementChild 1
CREATE Procedure [dbo].[GetPriceAgreementChild]
(
    @ID bigint = 0
)
As
BEGIN
   Select pch.ID As ID, pch.ParentID,pch.TestStandardID,pch.SampleTypeID,pch.RegularPrice,pch.ExpressPrice,
   pch.Note,pa.CustomerID,pa.CustomerSideSigneeName,tsd.Name As TestStandardName,tsd.TestNameID,spt.SampleCategoryID,
   spt.Name As SampleTypeName,spt.Description As SampleTypeDescription,pch.CurrencyID,curr.Name As CurrencyName,pch.IsActive
   from PriceAgreementChild_T pch 
   inner join dbo.PriceAgreementParent_T pa on pch.ParentID = pa.ID
   inner join dbo.Test_Standard_T tsd on pch.TestStandardID = tsd.ID
   inner join dbo.Sample_type_T spt on pch.SampleTypeID = spt.ID
   inner join dbo.Currency_T curr on pch.CurrencyID = curr.ID
   Where pch.ID = @ID or @ID = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetPriceAgreementParentAndChild_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetPriceAgreementParentAndChild_SP]
(
    @ID bigint
)
As 
BEGIN
     Select pap.ID,pap.CustomerID,cust.Name As CustomerName,pap.AgreementDate,pap.EffectiveDateFrom
	 ,pap.EffectiveDateTo,pach.ID As ChildID,pach.ParentID,pach.TestStandardID,ts.Name As TestStandardName,pach.RegularPrice,pach.ExpressPrice
	 ,pach.CurrencyID,cur.Name As CurrencyName
	 from PriceAgreementParent_T pap
	 inner join PriceAgreementChild_T pach on pap.ID = pach.ParentID
	 inner join Customer_T cust on pap.CustomerID = cust.ID
	 inner join Test_Standard_T ts on pach.TestStandardID = ts.ID
	 inner join Currency_T cur on pach.CurrencyID = cur.ID
	 Where pap.ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[GetProducer_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----EXEC [dbo].[GetProducer_SP]
CREATE Procedure [dbo].[GetProducer_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select p.ID AS ID,p.Name AS Name,p.Address AS Address,p.ContactPerson AS ContactPerson,p.Phone,p.IsActive from Producer_T p  where p.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetProject_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---EXEC [dbo].[GetProject_SP] 1
CREATE Procedure [dbo].[GetProject_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select p.ID AS ID,p.Name AS Name,p.ContactPerson AS ContactPerson,p.ContactPhone AS ContactPhone,p.ContactEmail,p.IsActive from Project_T p  where p.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetPyamentMethod_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetPyamentMethod_SP 
CREATE Procedure [dbo].[GetPyamentMethod_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select c.ID AS ID,c.Name AS Name,c.IsActive from Payment_Method_T  c  where c.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetSample_Category_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Exec [dbo].[GetSample_Category_SP] 1
CREATE Procedure [dbo].[GetSample_Category_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select cat.ID AS ID,cat.Name AS CategoryName,cat.IsActive from Sample_Category_T  cat  where cat.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetSample_Physical_Condition_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---EXEC GetSample_Physical_Condition_SP 1
CREATE Procedure [dbo].[GetSample_Physical_Condition_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select spc.ID AS ID,spc.Name AS Name,spc.Description AS Description,spc.IsActive from Sample_Physical_Condition_T spc  where spc.ID=@ID or @ID=0
End

GO
/****** Object:  StoredProcedure [dbo].[GetSample_type_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---EXEC [dbo].[GetSample_type_SP] 1
CREATE Procedure [dbo].[GetSample_type_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select tp.ID AS ID,tp.Name As Name, tp.Description AS Description,smpcat.Name As CategoryName,smpcat.ID As SampleCategoryID,tp.IsActive from Sample_type_T tp
	inner join Sample_Category_T smpcat on tp.SampleCategoryID = smpcat.ID
	Where tp.ID=@ID or @ID=0
End

GO
/****** Object:  StoredProcedure [dbo].[GetSampleTypeVsSpecificationType_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetSampleTypeVsSpecificationType_SP 
CREATE Procedure [dbo].[GetSampleTypeVsSpecificationType_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select 
	s.ID AS ID, 
	s.SampleTypeID,
	st.Name as SampleTypeName ,
	s.SpecificationHeadID,
	sh.Name as SpecificationHeadName,
	st.SampleCategoryID,
	s.IsActive
	from SampleType_VS_Specification_Type_T   s 
	inner join Sample_type_T st on s.SampleTypeID = st.ID
	inner join Specification_Head_T sh  on   s.SpecificationHeadID = sh.ID
	where s.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetSampleTypeVsTestStandard_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetSampleTypeVsTestStandard_SP 

CREATE Procedure [dbo].[GetSampleTypeVsTestStandard_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select 
	stt.ID AS ID, 
	stt.SampleTypeID,
	st.Name as SampleTypeName ,
	stt.TestStandardID,
	ts.Name as TestStandardName,
	stt.QtyPerSample As QtyPerSample,
	stt.ReqNumberOfSamplePcs,
	stt.ReqSampleDescription,
	stt.IsActive
	from SampleType_VS_TestStandard_T   stt
	inner join Sample_type_T st on stt.SampleTypeID = st.ID
	inner join Test_Standard_T ts on   stt.TestStandardID = ts.ID
	where stt.ID=@ID or @ID=0
End

GO
/****** Object:  StoredProcedure [dbo].[GetSection_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetSection_SP 
CREATE Procedure [dbo].[GetSection_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select s.ID AS ID,s.Name AS Name,s.CompanyID,com.Name As CompanyName, s.isActive As IsActive from Section_T  s 
	inner join Company_T com on s.CompanyID = com.ID
	where s.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetSpecificationHead_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetSpecificationHead_SP 
CREATE Procedure [dbo].[GetSpecificationHead_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select s.ID AS ID,
	s.Name AS Name,
	s.MeasurementUnitID,
	mu.Name MeasurementUnitName,
	s.IsActive
	from Specification_Head_T  s  
	left join Measurement_Unit_T mu
	on s.MeasurementUnitID = mu.ID
	where s.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetTestName_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetTestName_SP]
@ID bigint = 0
As
Begin
   Select ts.ID AS ID, ts.Name As TestName,ts.TestGroupAttributeID As TestGroupAttributeID,att.Name As AttributeName,ts.IsActive from dbo.Test_Name_T ts
   inner join dbo.Attribute_T att on ts.TestGroupAttributeID = att.ID
   Where ts.ID = @ID OR @ID = 0 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTestSampleInfo]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[GetTestSampleInfo]  
(
	@CustomerID bigint,
	@CurrencyCode bigint
)
As 
Begin 
	SELECT  SC.ID as SampleCategoryId
      ,SC.Name as SampleCategoryName
     ,ST.ID as SampleTypeID,
	 ST.Name as SampleTypeName
	 ,st.DefaultMeasurementUnitId
	 ,Unit.Name as UnitName
	,TS.ID As TestStandardID 
	,TS.Name as TestStandardName
	,TN.ID as TestNameID
	,TN.Name as TestName
	,STVSTS.ReqNumberOfSamplePcs
	,STVSTS.QtyPerSample
	,convert(decimal(18,3),0.000) as RegularPrice
	,convert(decimal(18,3),0.000) as ExpressPrice
	,0 as RegularDeliveryDays
	,0 as ExpressDeliveryDays
	,SC.IsActive
	into #Temp
  FROM  Sample_Category_T as SC 
  inner join Sample_type_T as ST on SC.ID=ST.SampleCategoryID
  inner join SampleType_VS_TestStandard_T as STVSTS on ST.ID=STVSTS.SampleTypeID
  inner join Test_Standard_T as TS on TS.ID=STVSTS.TestStandardID
  inner join Test_Name_T as TN on TN.ID=TS.TestNameID
  inner join Measurement_Unit_T as Unit on Unit.ID=st.DefaultMeasurementUnitId
  where ST.IsActive=1 and SC.IsActive=1

  select t.TestStandardID,isnull(p.RegularPrice,0) as RegularPrice, isnull(p.ExpressPrice,0) as ExpressPrice , isnull(p.ExpressDeliveryDays,0) as ExpressDeliveryDays, isnull(p.RegularDeliveryDays,0) as RegularDeliveryDays
  into #StardardPrice
  from #Temp as T inner join Test_StandardWise_Price_T as P  on t.TestStandardID=p.TestStandardID and p.CurrencyID=@CurrencyCode
  group by t.TestStandardID,P.RegularPrice,p.ExpressPrice,p.ExpressDeliveryDays,p.RegularDeliveryDays
  
  select t.TestStandardID,isnull(pac.RegularPrice,0) as RegularPrice, isnull(pac.ExpressPrice,0) as ExpressPrice 
  into #PriceAggrementT
  from #Temp as T inner join PriceAgreementChild_T as PAC on t.TestStandardID=PAC.TestStandardID and pac.CurrencyID=@CurrencyCode 
  inner join PriceAgreementParent_T as PAP on PAC.ParentID=pap.ID and pap.CustomerID=@CustomerID
  group by t.TestStandardID,Pac.RegularPrice,pac.ExpressPrice

  update t set t.RegularPrice=isnull(isnull(pa.RegularPrice,sp.RegularPrice),0)
  ,t.ExpressPrice=isnull(isnull(pa.ExpressPrice,sp.ExpressPrice),0)
  , t.RegularDeliveryDays=isnull(sp.RegularDeliveryDays,0)
  ,t.ExpressDeliveryDays=isnull(sp.ExpressDeliveryDays,0)
  from #Temp as T left join #StardardPrice as SP on t.TestStandardID=sp.TestStandardID left join #PriceAggrementT as PA
  on pa.TestStandardID=t.TestStandardID
  select * from #Temp

  drop table #Temp
  drop table #StardardPrice
  drop table #PriceAggrementT
End

GO
/****** Object:  StoredProcedure [dbo].[GetTestStandard_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetTestStandard_SP 
CREATE Procedure [dbo].[GetTestStandard_SP]
(
	@ID INT = 0
)
As 
Begin 
	Select t.ID As TestStandardID, t.Name As TestStandardName,ts.TestGroupAttributeID,ts.ID As TestNameID,ts.Name As TestName, t.IsActive from Test_Standard_T  t 
	inner join Test_Name_T ts on t.TestNameID = ts.ID
	where t.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetTestStandardVsMachine_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----Exec GetTestStandardVsMachine_SP 
CREATE Procedure [dbo].[GetTestStandardVsMachine_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select 
	tsm.ID AS ID, 
	tsm.TestStandardID,
	ts.Name as TestStandardName ,
	tsm.MachineID,
	m.Name as MachineName,
	tsm.IsActive
	from Test_StandardVSMachine_T   tsm
	left join Test_Standard_T ts on tsm.TestStandardID = ts.ID
	left join Machine_T m  on   tsm.MachineID = m.ID
	where tsm.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetTestStandardWisePrice_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetTestStandardWisePrice_SP]
(
	@ID INT = 0
)
As 
Begin 
	Select tpr.ID As TestStandardWisePriceID,tpr.TestStandardID As TestStandardWiseID,tpr.CurrencyID As CurrencyWiseID,tpr.RegularDeliveryDays,tpr.ExpressDeliveryDays,tpr.RegularPrice,tpr.ExpressPrice,tpr.EffectiveDateFrom,
	ISNULL(tpr.EffectiveDateTo,'') As EffectiveDateTo,st.Name As TestStandardWiseName,st.TestNameID As TestNameWiseID,cr.Name As CurrencyWiseName,cr.ShortName As ShortName,tpr.IsActive
	from Test_StandardWise_Price_T  tpr
	inner join dbo.Test_Standard_T st on tpr.TestStandardID = st.ID
	inner join dbo.Currency_T cr on tpr.CurrencyID = cr.ID
	where tpr.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[GetUser_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----Exec GetUser_SP 
CREATE Procedure [dbo].[GetUser_SP]
(
	@ID INT = 0
)
as 
Begin 
	Select usr.ID As ID, usr.Name,usr.UserName,usr.Email,usr.Designation,usr.UserTypeAttributeID,usr.Password,
	att.Name As UserTypeAttributeName,usr.UserSectionID,sect.Name As UserSectionName
	from User_T  usr 
	inner join Attribute_T att on usr.UserTypeAttributeID = att.ID
	inner join Section_T sect on usr.UserSectionID = sect.ID
	where usr.ID=@ID or @ID=0
End
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateAttribute_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateAttribute_SP 0,'AttType',1,1,1 
CREATE Procedure [dbo].[InsertUpdateAttribute_SP]
(
	@ID bigint,
	@Name varchar(500),
	@AttributeTypeID bigint,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Attribute_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Attribute_T 
			 SET Name = @Name,
			 AttributeTypeID = @AttributeTypeID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Attribute_T (
			      GID,
				  Name,
				  AttributeTypeID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@AttributeTypeID,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateAttributeType_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



----EXEC InsertUpdateAttributeType_SP 0,'TypeName',1,1 
CREATE Procedure [dbo].[InsertUpdateAttributeType_SP]
(
	@ID bigint,
	@Name varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Attribute_Type_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Attribute_Type_T 
			 SET Name = @Name,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Attribute_Type_T(
			      GID,
				  Name,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			   newid(),
				@Name,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		ELSE
		BEGIN
		    set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		END
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateCalibrationFrequency_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateMeasurementUnit_SP 0,'Gram','Gram per unit',1,1
CREATE Procedure [dbo].[InsertUpdateCalibrationFrequency_SP]
(
	@ID bigint,
	@MachineID int,
	@CorrectionFactor decimal(18,5),
	@MeasurementUnitID int,
	@EffectiveDate datetime,
	@CalibrationFrequencyDays int,
	@CalibrationFrequencyInTestNumber int,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE Calibration_Frequency_T
			 SET MachineID = @MachineID,
			 CorrectionFactor = @CorrectionFactor,
			 MeasurementUnitID = @MeasurementUnitID,
			 EffectiveDate = @EffectiveDate,
			 CalibrationFrequencyInDays = @CalibrationFrequencyDays,
			 CalibrationFrequencyInTestNumber = @CalibrationFrequencyInTestNumber,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Calibration_Frequency_T(
			       GID,
				    MachineID,
					CorrectionFactor,
					MeasurementUnitID,
					EffectiveDate,
					CalibrationFrequencyInDays,
					CalibrationFrequencyInTestNumber,
				    IsActive,
				    Creator,
				    CreationDate
				)
			VALUES (
			    newid(),
				@MachineID, 
				@CorrectionFactor,
				@MeasurementUnitID,
				@EffectiveDate,
				@CalibrationFrequencyDays,
				@CalibrationFrequencyInTestNumber,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateCompany_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateCompany_SP 0,'RavenSystems','logo','ravensystems.com','ravens@gmail.com','01342345638','Uttara','fax','15 number','300km',1,1 
CREATE Procedure [dbo].[InsertUpdateCompany_SP]
(
	@ID bigint,
	@Name varchar(500),
	@Logo varchar(500),
	@WebsiteAddress varchar(500),
	@EmailAddress varchar(500),
	@PhoneNumber varchar(500),
	@PhysicalAddress varchar(500),
	@Fax varchar(500),
	@LocationLat varchar(500),
	@LocationLng varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Company_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Company_T 
			 SET Name = @Name,
			 Logo = @Logo,
			 WebsiteAddress = @WebsiteAddress,
			 EmailAddress = @EmailAddress,
			 PhoneNumber = @PhoneNumber,
			 PhysicalAddress = @PhysicalAddress,
			 Fax = @Fax,
			 LocationLat = @LocationLat,
			 LocationLng = @LocationLng,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Company_T(
			      gid,
				  Name,
				  Logo,
				  WebsiteAddress,
				  EmailAddress,
				  PhoneNumber,
				  PhysicalAddress,
				  Fax,
				  LocationLat,
				  LocationLng,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@Logo,
				@WebsiteAddress,
				@EmailAddress,
				@PhoneNumber,
				@PhysicalAddress,
				@Fax,
				@LocationLat,
				@LocationLng,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateCurrency_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----EXEC InsertUpdateCurrency_SP 0,'SampleDescription','ShortName',1,1 
CREATE Procedure [dbo].[InsertUpdateCurrency_SP]
(
	@ID bigint,
	@Name varchar(500),
	@ShortName varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Currency_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Currency_T 
			 SET Name = @Name,
			 ShortName = @ShortName,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Currency_T (
			      GID,
				  Name,
				  ShortName,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@ShortName,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateCustomer_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateCustomer_SP 0,'Omar','faruk','faruk@gmail.com','Dhanmondi','01311828760',1,1
CREATE Procedure [dbo].[InsertUpdateCustomer_SP]
(
	@ID bigint,
	@Name varchar(500),
    @ContactPersonName varchar(500),
    @ContactEmail varchar(500),
    @ContactAddress varchar(500),
    @ContactPhone varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Customer_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Customer_T
			 SET Name = @Name,
			 ContactPersonName = @ContactPersonName,
			 ContactEmail = @ContactEmail,
			 ContactAddress = @ContactAddress,
			 ContactPhone = @ContactPhone,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Customer_T (
			      GID,
				  Name,
				  ContactPersonName,
				  ContactEmail,
				  ContactAddress,
				  ContactPhone,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@ContactPersonName  ,
				@ContactEmail,
				@ContactAddress,
				@ContactPhone,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDocUpload_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



----EXEC InsertUpdateDocUpload_SP 0,0,0,'docName','.doc','Transaction',1,1 
CREATE Procedure [dbo].[InsertUpdateDocUpload_SP]
(
	@ID bigint,
	@TransactionTypeAttributeID bigint,
	@TransactionID bigint,
	@DocName varchar(500),
	@DocExtension varchar(500),
	@FileName varchar(200),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE DocUpload_T 
			 SET TransactionTypeAttributeID = @TransactionTypeAttributeID,
			 TransactionID = @TransactionID,
			 DocName = @DocName,
			 DocExtension = @DocExtension,
			 FileName = @FileName,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO DocUpload_T (
			      GID,
				  TransactionTypeAttributeID,
				  TransactionID,
				  DocName,
				  DocExtension,
				  FileName,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@TransactionTypeAttributeID,
				@TransactionID,
				@DocName,
				@DocExtension,
				@FileName,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateMachine_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



----EXEC InsertUpdateMachine_SP 0,'BMW','Jawtype',1,1,1 
CREATE Procedure [dbo].[InsertUpdateMachine_SP]
(
	@ID bigint,
	@Name varchar(500),
	@JawType varchar(500)='',
	@MachineTypeAttributeID bigint,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Machine_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Machine_T 
			 SET Name = @Name,
			 JawType = @JawType,
			 MachineTypeAttributeID = @MachineTypeAttributeID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Machine_T (
			      GID,
				  Name,
				  JawType,
				  MachineTypeAttributeID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@JawType,
				@MachineTypeAttributeID,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateMeasurementUnit_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateMeasurementUnit_SP 0,'Gram','Gram per unit',1,1
CREATE Procedure [dbo].[InsertUpdateMeasurementUnit_SP]
(
	@ID bigint,
	@Name varchar(500),
    @Description varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Measurement_Unit_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Measurement_Unit_T
			 SET Name = @Name,
			 Description = @Description,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Measurement_Unit_T (
			      GID,
				  Name,
				  Description,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@Description,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateOrder_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[InsertUpdateOrder_SP]
(											
	@ID int,
	@CustomerId bigint,
	@ContactName varchar(100),
	@ContactMobile varchar(20),
	@ContactAddress varchar(100),
	@ProjectId bigint,
	@OrderDate datetime,
	@CurrencyCode bigint,	
    @Creator bigint,
	@OrderEntryChild xml,
	@ContactEmail varchar(100),
	@Description varchar(100),
	@PaymentMode varchar(100),
	@DiscountAmount varchar(100)
)

AS
BEGIN
	   DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit,@GID nvarchar(max)
		DECLARE @OutlstOfData int 
		Create table #Temp_Child (
			    ID bigint,
				ParentID bigint,
				BatchLot varchar(100),
				Producer bigint,
				SampleCategoryId bigint,
				TestId bigint,
				SampleTypeId bigint,
				TestStandardId bigint,
				QtyPerSample int,
				MeasurementUnitId bigint,
				ReqNumberOfSamplePcs int,
				Price decimal(18,3),
				SampleID bigint NULL,
				DeliveryDate datetime
				
			)
			 	if(convert(nvarchar(max), @OrderEntryChild)<>'')
		begin
		
		 EXEC sp_xml_preparedocument @OutlstOfData OUTPUT, @OrderEntryChild	
  				INSERT INTO #Temp_Child
					SELECT ID	,ParentID,BatchLot , Producer,SampleCategoryId,TestId,	SampleTypeId,TestStandardId,QtyPerSample,MeasurementUnitId,ReqNumberOfSamplePcs,Price,NULL,DeliveryDate
						FROM Openxml( @OutlstOfData,'/OrderEntryChildList/child', 3) 
						WITH 
						( 
							ID [int] ,
							ParentID [int] ,
							BatchLot [nvarchar] ,
							Producer [int],
							SampleCategoryId [int],
							TestId [int],
							SampleTypeId [int],
							TestStandardId [int],
						    QtyPerSample int,
							MeasurementUnitId int,
							ReqNumberOfSamplePcs int,
							Price decimal(18,3),
							SampleID int,
							DeliveryDate datetime
						)
					
      end
	 
	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE Order_Parent_T 
			 SET CustomerID = @CustomerId
			  ,ContactName = @ContactName
			  ,ContactMobile = @ContactMobile
			  ,ContactAddress = @ContactAddress
			  ,ProjectId = @ProjectId
			  ,OrderDate = @OrderDate
			  ,CurrencyCode = @CurrencyCode
			  ,ContactEmail = @ContactEmail
			  ,Description = @Description
			  ,PaymentMode = @PaymentMode
			  ,DiscountAmount = @DiscountAmount
			  ,Modifier = @Creator
			  ,ModificationDate = GETDATE()
				WHERE ID = @ID 

				SET @IDOut = @ID


			 update OrderChildSample set 
		     OrderChildSample.LotNo = T.BatchLot,
			 OrderChildSample.SampleTypeID = T.SampleTypeId,
			 OrderChildSample.ProducerID = T.Producer,
			 OrderChildSample.MeasurementUnitID = T.MeasurementUnitID,
			 OrderChildSample.ReqNumberOfSamplePcs = T.ReqNumberOfSamplePcs,
			 OrderChildSample.QtyPreSample = T.QtyPerSample, 
			 OrderChildSample.ModificationDate=GETDATE(),
			 OrderChildSample.Modifier=@Creator
			 from  #Temp_Child as T inner join Order_Child_Sample_T as OrderChildSample on  T.SampleID=OrderChildSample.ID where OrderChildSample.ParentID=@ID

				Insert into Order_Child_Sample_T
				(ParentID,SampleTypeID,ProducerID,MeasurementUnitID,ReqNumberOfSamplePcs,QtyPreSample)
				select distinct @IDOut,SampleTypeId,Producer,MeasurementUnitID,ReqNumberOfSamplePcs,QtyPerSample from #Temp_Child  as T where isnull(T.SampleID,0)=0

				update T set t.SampleID=OrderSampleChild.ID
				from #Temp_Child as T inner join Order_Child_Sample_T as OrderSampleChild on T.SampleTypeId=OrderSampleChild.SampleTypeID and 
				T.BatchLot=OrderSampleChild.LotNo and  T.Producer=OrderSampleChild.ProducerID			 
				where OrderSampleChild.ParentID=@ID and isnull(t.SampleID,0)=0
           
		   
				delete from Order_Child_Sample_T where id in (
				select OrderSampleChild.ID from #Temp_Child as T right join Order_Child_Sample_T as OrderSampleChild on OrderSampleChild.ParentID=@id and t.SampleID=OrderSampleChild.ID and t.SampleID is null)


				set @IsSuccess=1
				SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Order_Parent_T(
			      GID,
				   CustomerID
				  ,ContactName
				  ,ContactMobile
				  ,ContactAddress
				  ,ProjectId 
				  ,OrderDate
				  ,CurrencyCode
				  ,ContactEmail
				  ,Description
				  ,PaymentMode
				  ,DiscountAmount
				  ,Creator
				  ,CreationDate
				  )
			VALUES (
			   newid(),
				@CustomerId,
				@ContactName,
				@ContactMobile,
				@ContactAddress,
				@ProjectId,
				@OrderDate,
				@CurrencyCode,
			    @ContactEmail,
		        @Description,
				@PaymentMode,
				@DiscountAmount,
				--@IsActive,
				@Creator,
				GETDATE()
				)
				
			 SET @IDOut = SCOPE_IDENTITY() 
			 Insert into Order_Child_Sample_T
			 (ParentID,LotNo,SampleTypeID, ProducerID,MeasurementUnitID,ReqNumberOfSamplePcs,QtyPreSample)
			 select distinct @IDOut,BatchLot,SampleTypeID,Producer,MeasurementUnitID,ReqNumberOfSamplePcs,QtyPerSample from #Temp_Child
	
			update T set t.SampleID=OrderSampleChild.ID
			 from #Temp_Child as T inner join Order_Child_Sample_T as OrderSampleChild on T.SampleTypeId=OrderSampleChild.SampleTypeID and 
			  T.BatchLot=OrderSampleChild.LotNo and  T.Producer=OrderSampleChild.ProducerID  where OrderSampleChild.ParentID=@IDOut
			 

INSERT INTO [dbo].[Order_Child_Test_Standard_T]
           ([GID]
           ,[SampleID]
           ,[TestStandardID]
           ,[QtyNumber]
           ,[UnitPrice]
		   ,DeliveryDate
           ,[Creator]
           ,[CreationDate]
           )
			SELECT 
      newid()
      ,t.SampleID
      ,TestStandardID
      ,QtyPerSample
      ,Price
	  ,DeliveryDate
      ,@Creator,
	  GETDATE()
  FROM  #Temp_Child as T
	         
			
			set @IsSuccess=1 
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION
		drop table #Temp_Child
		select @GID=GID from Order_Parent_T where id=@IDOut
		SELECT @IDOut AS ID,@GID as GID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess


		ROLLBACK TRANSACTION
	END CATCH
		
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdatePaymentMethod_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdatePaymentMethod_SP 0,'Bcash',1,1 
CREATE Procedure [dbo].[InsertUpdatePaymentMethod_SP]
(
	@ID bigint,
	@Name varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF Not Exists (select * from Payment_Method_T where Name=@Name and ID<>@ID)
		Begin
		IF (@ID > 0)
		BEGIN  
		     UPDATE Payment_Method_T 
			 SET Name = @Name,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Payment_Method_T(
			      GID,
				  Name,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			   newid(),
				@Name,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		End
		Else
		Begin
		   Set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		End
		COMMIT TRANSACTION
		
		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess
		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdatePriceAgreement_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC InsertUpdatePriceAgreement_SP 0,1,'2023-06-30','2023-09-30','2023-04-23','Desc',1,'Rahim','Manager',1,1,'<PriceAgreementChildList>
--  <child>
--    <ID>0</ID>
--    <ParentID>0</ParentID>
--    <TestStandardID>5</TestStandardID>
--    <SampleTypeID>1</SampleTypeID>
--    <RegularPrice>990</RegularPrice>
--    <ExpressPrice>22</ExpressPrice>
--    <CurrencyID>4</CurrencyID>
--    <Note />
--  </child>
--  <child>
--    <ID>0</ID>
--    <ParentID>0</ParentID>
--    <TestStandardID>1</TestStandardID>
--    <SampleTypeID>1</SampleTypeID>
--    <RegularPrice>77</RegularPrice>
--    <ExpressPrice>77</ExpressPrice>
--    <CurrencyID>55</CurrencyID>
--    <Note/>
--  </child>
--   <child>
--    <ID>0</ID>
--    <ParentID>0</ParentID>
--    <TestStandardID>1</TestStandardID>
--    <SampleTypeID>1</SampleTypeID>
--    <RegularPrice>60</RegularPrice>
--    <ExpressPrice>40</ExpressPrice>
--    <CurrencyID>21</CurrencyID>
--    <Note/>
--  </child>
--</PriceAgreementChildList>'

CREATE Procedure [dbo].[InsertUpdatePriceAgreement_SP]
(											
	@ID int,
	@AgreementCustomerID int,
	@AgreementDate date,
	@AgEffectiveDateFrom date,
	@AgEfffectiveDateTo date,
	@AgDescription varchar(max),
	@Signee_id varchar(50),
	@CustomerSideSigneeName varchar(100),
	@CustomerSideSigneeDesignation varchar(100),
    @IsActive bit,
    @Creator int,
	@PriceAgreementChild xml
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit
		DECLARE @OutlstOfData int 
		Create table #Temp_Child (
			    ID bigint,
				ParentID bigint,
				TestStandardID bigint,
				SampleTypeID bigint,
				RegularPrice decimal(18,3),
				ExpressPrice decimal(18,3),
				CurrencyID bigint,
				Note  nvarchar(max)
			)
			 
	 if(convert(nvarchar(max), @PriceAgreementChild)<>'')
		begin 
		 EXEC sp_xml_preparedocument @OutlstOfData OUTPUT, @PriceAgreementChild	
  				INSERT INTO #Temp_Child
					SELECT ID	,ParentID,	TestStandardID,	SampleTypeID,	RegularPrice,	ExpressPrice,	CurrencyID,	Note
						FROM Openxml( @OutlstOfData,'/PriceAgreementChildList/child', 3) 
						WITH 
						( 
							[ID] [int] ,
							[ParentID] [int] ,
							TestStandardID [int] ,
							SampleTypeID [int],	
							RegularPrice Decimal(18,2),	
							ExpressPrice Decimal(18,2),
							CurrencyID [int],
							Note [nvarchar](max),
							IsActive [bit],
							Creator [int],
							CreationDate [date]
						)

      end
	 
	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE PriceAgreementParent_T 
			 SET CustomerID = @AgreementCustomerID
			  ,AgreementDate = @AgreementDate
			  ,EffectiveDateFrom = @AgEffectiveDateFrom
			  ,EffectiveDateTo = @AgEfffectiveDateTo
			  ,Description = @AgDescription
			  ,Signee_id = @Signee_id
			  ,CustomerSideSigneeName =@CustomerSideSigneeName
			  ,CustomerSideSigneeDesignation = @CustomerSideSigneeDesignation
			  ,IsActive = @IsActive
			  ,Modifier = @Creator
			  ,ModificationDate = GETDATE()
				WHERE ID = @ID 


				
				delete from PriceAgreementChild_T where id in (
				select pach.ID from #Temp_Child as T 
				 right join PriceAgreementChild_T as pach on   t.id=pach.id AND pach.ParentID=@ID  
			  where t.ID is null) and parentId=@ID

				UPDATE mt
				SET 
				    mt.TestStandardID = tt.TestStandardID,
					mt.SampleTypeID = tt.SampleTypeID,
					mt.RegularPrice = tt.RegularPrice,
					mt.ExpressPrice = tt.ExpressPrice,
					mt.CurrencyID = tt.CurrencyID,
					mt.Note = tt.Note,
					mt.IsActive = @IsActive, 
					mt.ModificationDate = GETDATE(),
					mt.Modifier = @Creator
				FROM #Temp_Child tt 
				inner join PriceAgreementChild_T mt ON mt.ParentID = tt.ParentID
				Where mt.ID = tt.ID

				Insert into PriceAgreementChild_T 
				(ParentID,TestStandardID,SampleTypeID,RegularPrice,ExpressPrice,CurrencyID,Note,IsActive,Creator,CreationDate)
				select distinct @ID,TestStandardID,SampleTypeId,RegularPrice,ExpressPrice,CurrencyID,Note,@IsActive,@Creator,
				GETDATE() from #Temp_Child  as T where isnull(T.ID,0)=0
				 
				SET @IDOut = @ID
				set @IsSuccess=1
				SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO PriceAgreementParent_T(
			       GID,
				   CustomerID
				  ,AgreementDate
				  ,EffectiveDateFrom
				  ,EffectiveDateTo
				  ,Description 
				  ,Signee_id
				  ,CustomerSideSigneeName
				  ,CustomerSideSigneeDesignation
				  ,IsActive
				  ,Creator
				  ,CreationDate
				  )
			VALUES (
			   newid(),
				@AgreementCustomerID,
				@AgreementDate,
				@AgEffectiveDateFrom,
				@AgEfffectiveDateTo,
				@AgDescription,
				@Signee_id,
				@CustomerSideSigneeName,
				@CustomerSideSigneeDesignation,
				@IsActive,
				@Creator,
				GETDATE()
				)
				
			SET @IDOut = SCOPE_IDENTITY() 
			   INSERT INTO PriceAgreementChild_T
			        (ParentID,TestStandardID,SampleTypeID,RegularPrice,ExpressPrice,CurrencyID,Note,IsActive,Creator,CreationDate)
				    SELECT @IDOut,TestStandardID,SampleTypeID,RegularPrice,	ExpressPrice,CurrencyID,Note,1,@Creator,GETDATE() from #Temp_Child
			 		
	DECLARE @NewIds TABLE(ChildID INT)

--INSERT INTO PriceAgreementChild_T
--(ParentID,TestStandardID,SampleTypeID,RegularPrice,ExpressPrice,CurrencyID,Note,IsActive,Creator,CreationDate)
				    
--OUTPUT inserted.ID INTO @NewIds(ChildID)
--SELECT @IDOut,TestStandardID,SampleTypeID,RegularPrice,	ExpressPrice,CurrencyID,Note,1,@Creator,GETDATE() from #Temp_Child


			set @IsSuccess=1 
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION
		 drop table #Temp_Child
	   SELECT @IDOut AS ID, @Message AS Message , convert(bit, @IsSuccess) as IsSuccess
		
		--SELECT * FROM @NewIds  As ChildID
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateProducer_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC [dbo].[InsertUpdateProducer_SP] 1,'obaydullah','Mirpur','Safik','019883883902',1,1
CREATE Procedure [dbo].[InsertUpdateProducer_SP]
(
	@ID bigint,
	@Name varchar(500),
    @Address varchar(500),
	@ContactPerson varchar(500),
	@Phone varchar(50),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Producer_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Producer_T
			 SET Name = @Name,
			 Address = @Address,
			 ContactPerson = @ContactPerson,
			 Phone = @Phone,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Producer_T (
			     GID,
				  Name,
				  Address,
			      ContactPerson,
			      Phone,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@Address  ,
				@ContactPerson,
				@Phone,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateProject_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC [dbo].[InsertUpdateProject_SP] 0,'RSL LAB','dell','0164939032','amir@gamil.com',1,1
CREATE Procedure [dbo].[InsertUpdateProject_SP]
(
	@ID bigint,
	@Name varchar(500),
	@contactPerson varchar(500),
	@contactPhone varchar(50),
	@contactEmail varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Project_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Project_T
			 SET Name = @Name,
			 ContactPerson = @contactPerson,
			 ContactPhone = @contactPhone,
			 ContactEmail = @contactEmail,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Project_T (
			      GID,
				  Name,
				  ContactPerson,
				  ContactPhone,
				  ContactEmail,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@contactPerson,
				@contactPhone,
				@contactEmail,
				@isActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		    set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID ,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSample_PhysicalConditon_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC [dbo].[InsertUpdateSample_PhysicalConditon_SP] 0,'05','Description',1,1
CREATE Procedure [dbo].[InsertUpdateSample_PhysicalConditon_SP]
(
	@ID bigint,
    @Name varchar(500),
	@Description varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Sample_Physical_Condition_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Sample_Physical_Condition_T
			 SET Name = @Name,
			 Description = @Description,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Sample_Physical_Condition_T (
			      GID,
				  Name,
				  Description,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@Description,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSample_Specification_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC [dbo].[InsertUpdateSample_Specification_SP] 0,'05',1,1
CREATE Procedure [dbo].[InsertUpdateSample_Specification_SP]
(
	@ID bigint,
    @Dimension varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE Sample_Specification_T
			 SET Dimension = @Dimension,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Sample_Specification_T (
				  Dimension,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
				@Dimension,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSample_type_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC [dbo].[InsertUpdateSample_type_SP] 0,'SampleName 01','SampleDescription 01',1,1 
CREATE Procedure [dbo].[InsertUpdateSample_type_SP]
(
	@ID bigint,
	@Name varchar(500),
	@SampleCategoryID int,
    @Description varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Sample_type_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Sample_type_T 
			 SET Name = @Name,
			 SampleCategoryID = @SampleCategoryID,
			 Description = @Description,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Sample_type_T (
			      GID,
				  Name,
				  SampleCategoryID,
				  Description,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@SampleCategoryID,
				@Description,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		Else
		Begin
		   Set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		End
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSampleCategory_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



----EXEC InsertUpdateSampleCategory_SP 0,'Iron',1,1 
CREATE Procedure [dbo].[InsertUpdateSampleCategory_SP]
(
	@ID bigint,
	@Name varchar(500), 
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Sample_Category_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE  Sample_Category_T 
			 SET Name = @Name, 
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Sample_Category_T (
			      GID,
				  Name, 
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			newid(),
				@Name, 
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		Else
		Begin
		   Set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		End
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSampleReceive_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC InsertUpdateSampleReceive_SP 0,98,2,1,2,'2023-09-09','Note',1,1,
--'<SamplesSpecificationList>
--  <child>
--    <ID>0</ID>
--    <SampleID>98</SampleID>
--    <SpecificationID>1</SpecificationID>
--    <SpecificationValue>66</SpecificationValue>
--    <Creator>1</Creator>
--    <CreationDate>2023-08-21T00:00:00</CreationDate>
--  </child>
--</SamplesSpecificationList>'

CREATE Procedure [dbo].[InsertUpdateSampleReceive_SP]
(
	@ID bigint, 
	@SampleID bigint, 
	@NumberOfSamplePcs bigint,
	@QtyPerSample bigint,
	@ReceivedByID bigint,
	@ReceivedDateTime date,
	@Note varchar(500),
	@IsActive bit,
	@Creator bigint,
	@OrderChildSampleConditionList xml,
	@SamplesSpecificationList xml
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

		DECLARE @OutlstOfPhysicalCondtionData int 
		Create table #Temp_OrderChildSampleConditionList (
			    ID bigint,
				SampleID bigint,
				SampleConditionID bigint
			)
			if(convert(nvarchar(max), @OrderChildSampleConditionList)<>'')
		begin 
		 EXEC sp_xml_preparedocument @OutlstOfPhysicalCondtionData OUTPUT, @OrderChildSampleConditionList	
  				INSERT INTO #Temp_OrderChildSampleConditionList
					SELECT ID,SampleID, SampleConditionID 
						FROM Openxml( @OutlstOfPhysicalCondtionData,'/OrderChildSampleConditionList/child', 3) 
						WITH 
						( 
							[ID] [int],
							[SampleID] [int],
							[SampleConditionID] [int],
							[Creator] [int],
							[CreationDate] [date]
						)
          end

		  --------SamplesSpecificationList----------
		DECLARE @OutlstOfData int 
		Create table #Temp_Child (
			    ID bigint,
				SampleID bigint,
				SpecificationID bigint,
				SpecificationValue decimal(18,3),
			)
			if(convert(nvarchar(max), @SamplesSpecificationList)<>'')
		begin 
		 EXEC sp_xml_preparedocument @OutlstOfData OUTPUT, @SamplesSpecificationList	
  				INSERT INTO #Temp_Child
					SELECT ID,SampleID, SpecificationID,SpecificationValue
						FROM Openxml( @OutlstOfData,'/SamplesSpecificationList/child', 3) 
						WITH 
						( 
							[ID] [int],
							[SampleID] [int],
							[SpecificationID] [int],
							[SpecificationValue] [decimal],
							Creator [int],
							CreationDate [date]
						)
      end
	  -----------------SamplesSpecificationList--------------
	BEGIN TRY
		BEGIN TRANSACTION
		IF (@ID > 0)
		BEGIN  
		     UPDATE  Sample_Receive_T
			 SET SampleID = @SampleID,
				NumberOfSamplePcs = @NumberOfSamplePcs ,
				QtyPerSample =	@QtyPerSample,
				ReceivedByID =	@ReceivedByID ,
				ReceivedDateTime =	@ReceivedDateTime,
				Note =	@Note, 
				IsActive = @IsActive,
				Modifier = @Creator,
				ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Sample_Receive_T(
				  SampleID,
				  NumberOfSamplePcs,
				  QtyPerSample,
				  ReceivedByID,
				  ReceivedDateTime,
				  Note,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
				@SampleID,
				@NumberOfSamplePcs,
				@QtyPerSample,
				@ReceivedByID,
				GETDATE(),
				@Note,
				1,
				@Creator,
				GETDATE()
				) 

			        INSERT INTO Order_Child_Sample_Condition_T
			        (SampleID,SampleConditionID,IsActive,Creator,CreationDate)
				    SELECT SampleID,SampleConditionID,@IsActive,@Creator,GETDATE() from #Temp_OrderChildSampleConditionList

			        INSERT INTO Order_Child_Sample_Specification_T
			        (SampleID,Specification_ID,Specification_Value,Creator,CreationDate)
				    SELECT SampleID,SpecificationID,SpecificationValue,@Creator,GETDATE() from #Temp_Child

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		COMMIT TRANSACTION
		SELECT @IDOut AS ID,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess
		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSampleTypeVsSpecificationType_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateSampleTypeVsSpecificationType_SP 0,1,1,1,1
CREATE Procedure [dbo].[InsertUpdateSampleTypeVsSpecificationType_SP]
(
	@ID bigint,
    @SampleTypeID int,
	@SpecificationHeadID int,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE SampleType_VS_Specification_Type_T
			 SET 
			 SampleTypeID = @SampleTypeID,
			 SpecificationHeadID = @SpecificationHeadID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO SampleType_VS_Specification_Type_T (
			       GID,
			       SampleTypeID,
				  SpecificationHeadID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
			    @SampleTypeID,
				@SpecificationHeadID,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSampleTypeVsTestStandard_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateSampleTypeVsSpecificationType_SP 0,1,1,1,1,'ddd',1,1
CREATE Procedure [dbo].[InsertUpdateSampleTypeVsTestStandard_SP]
(
	@ID bigint,
    @SampleTypeID int,
	@TestStandardID int,
	@ReqNumberOfSamplePcs int,
	@QtyPerSample decimal(18, 3),
	@ReqSampleDescription varchar(200),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE SampleType_VS_TestStandard_T
			 SET 
			 SampleTypeID = @SampleTypeID,
			 TestStandardID = @TestStandardID,
			 ReqNumberOfSamplePcs = @ReqNumberOfSamplePcs,
			 QtyPerSample = @QtyPerSample,
			 ReqSampleDescription =@ReqSampleDescription,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO SampleType_VS_TestStandard_T (
			       GID,
			       SampleTypeID,
				  TestStandardID,
				  ReqNumberOfSamplePcs,
				  QtyPerSample,
				  ReqSampleDescription,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
			    @SampleTypeID,
				@TestStandardID,
				@ReqNumberOfSamplePcs,
				@QtyPerSample,
				@ReqSampleDescription,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSection_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateSection_SP 0,'test',1,1,1
CREATE Procedure [dbo].[InsertUpdateSection_SP]
(
	@ID bigint,
	@Name varchar(500),
    @CompanyID int,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Section_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Section_T
			 SET Name = @Name,
			 CompanyID = @CompanyID,
			 IsActive = @IsActive,
			 Modifire = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Section_T (
			      GID,
				  Name,
				  CompanyID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@CompanyID ,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		Else
		Begin
		   Set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		End
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateSpecification_Head_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateSpecification_Head_SP 0,'test',1,1,1
CREATE Procedure [dbo].[InsertUpdateSpecification_Head_SP]
(
	@ID bigint,
	@Name varchar(500),
    @MeasurementUnitID int,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Specification_Head_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Specification_Head_T
			 SET Name = @Name,
			 MeasurementUnitID = @MeasurementUnitID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Specification_Head_T (
			      GID,
				  Name,
				  MeasurementUnitID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@MeasurementUnitID ,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		Else
		Begin
		   Set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		End
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateTest_Name_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateTest_Name_SP 0,'Group Test 01',1,1,1
CREATE Procedure [dbo].[InsertUpdateTest_Name_SP]
(
	@ID bigint,
	@Name varchar(500),
	@TestGroupAttributeID bigint, 
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Test_Name_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Test_Name_T
			 SET Name = @Name,
			 TestGroupAttributeID = @TestGroupAttributeID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Test_Name_T (
			      GID,
				  Name,
				  TestGroupAttributeID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name, 
				@TestGroupAttributeID,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		END
		else
		begin
		   set @IsSuccess=0
			SET @Message =  'Save failed due to duplicate data for '+@Name
		end
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID ,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateTestStandard_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateTestStandard_SP 0,'Standard',1,1,1 
CREATE Procedure [dbo].[InsertUpdateTestStandard_SP]
(
	@ID bigint,
	@Name varchar(500),
	@TestNameID bigint,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION
		IF NOT EXISTS(Select * from Test_Standard_T Where Name = @Name and ID <> @ID)
		BEGIN
		IF (@ID > 0)
		BEGIN  
		     UPDATE Test_Standard_T 
			 SET Name = @Name,
			 TestNameID = @TestNameID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Test_Standard_T (
			      GID,
				  Name,
				  TestNameID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@Name,
				@TestNameID,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END
		END
		Else
		BEGIN
		 Set @IsSuccess = 0
		 Set @Message = 'Save failed due to duplicate data for '+@Name
		END
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateTestStandardVsMachine_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateTestStandardVsMachine_SP 0,1,1,1,1
CREATE Procedure [dbo].[InsertUpdateTestStandardVsMachine_SP]
(
	@ID bigint,
    @TestStandardID bigint,
	@MachineID bigint,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE Test_StandardVSMachine_T
			 SET 
			 TestStandardID = @TestStandardID,
			 MachineID = @MachineID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Test_StandardVSMachine_T (
			      GID,
			      TestStandardID,
				  MachineID,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
			    @TestStandardID,
				@MachineID,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateTestStandardWisePrice_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----EXEC InsertUpdateTestStandardWisePrice_SP 0,2,3,4,5,23,32,'2023-06-30','2023-09-30',1,1 
CREATE Procedure [dbo].[InsertUpdateTestStandardWisePrice_SP]
(
	@ID bigint,
	@TestStandardID bigint,
	@CurrencyID bigint,
	@RegularDeliveryDays int,
	@ExpressDeliveryDays int,
	@RegularPrice decimal(18,2),
	@ExpressPrice decimal(18,2),
	@EffectiveDateFrom date,
	@EffectiveDateTo date,
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION

		IF (@ID > 0)
		BEGIN  
		     UPDATE Test_StandardWise_Price_T 
			 SET TestStandardID = @TestStandardID,
			 CurrencyID = @CurrencyID,
			 RegularDeliveryDays = @RegularDeliveryDays,
			 ExpressDeliveryDays = @ExpressDeliveryDays,
			 RegularPrice = @RegularPrice,
			 ExpressPrice = @ExpressPrice,
			 EffectiveDateFrom = @EffectiveDateFrom,
			 EffectiveDateTo = @EffectiveDateTo,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO Test_StandardWise_Price_T(
			      GID,
				  TestStandardID,
				  CurrencyID,
				  RegularDeliveryDays,
				  ExpressDeliveryDays,
				  RegularPrice,
				  ExpressPrice,
				  EffectiveDateFrom,
				  EffectiveDateTo,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES (
			    newid(),
				@TestStandardID,
				@CurrencyID,
				@RegularDeliveryDays,
				@ExpressDeliveryDays,
				@RegularPrice,
				@ExpressPrice,
				@EffectiveDateFrom,
				@EffectiveDateTo,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END

		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateUserInfo_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Select * from User_T
--EXEC InsertUpdateUserInfo_SP 0,'qabi','qabi','wabi@gmail.com','876','Support',2,3,1,1
--EXEC InsertUpdateUserInfo_SP 3,'billal','billal','billal@gmail.com','2580',1,'business',2,3,1,1

CREATE PROCEDURE [dbo].[InsertUpdateUserInfo_SP]
		@ID bigint,
		@Name varchar(500),
		@UserName varchar(500),
		@Email varchar(500),
		@Password varchar(500),
		@PasswordChange bit,
		@Designation varchar(500),
		@UserTypeAttributeID bigint,
		@UserSectionID bigint,
		@IsActive bit,
		@Creator bigint
 AS
 BEGIN
 BEGIN TRY
 BEGIN TRANSACTION
 DECLARE @IDOut bigint=0,@IsSuccess bit=0

 If (@PasswordChange > 0)
 Begin 
   Update User_T
   Set Name = @Name,
   Password = @Password
   Where ID = @ID 
    SET @IDOut = @ID
	SET @IsSuccess = 1
	SELECT @IDOut AS ID,'Password Changed Successfully' Message , convert(bit, @IsSuccess) as IsSuccess 
 END
 Else IF ( @ID = 0 )
 
 BEGIN 
	IF EXISTS(select * from User_T where Username=@Username)
		BEGIN
			SELECT @IDOut As ID,'Username already exists' Message,@IsSuccess IsSuccess
		END
	ELSE IF EXISTS(select * from User_t where Email=@Email)
		BEGIN
			SELECT @IDOut ID,'Email already exists' Message,@IsSuccess IsSuccess
		END
	ELSE
		BEGIN
			INSERT INTO User_T(
					  GID,
					  Name,
					  UserName,
					  Email,
					  Password,
					  Designation,
					  UserTypeAttributeID,
					  UserSectionID,
					  IsActive,
					  Creator,
					  CreationDate
					)
				VALUES (
					newid(),
					@Name,
					@UserName,
					@Email,
					@Password,
					@Designation,
					@UserTypeAttributeID,
					@UserSectionID,
					@IsActive,
					@Creator,
					GETDATE()
					) 

			SET @IDOut = SCOPE_IDENTITY()
			SET @IsSuccess = 1
			SELECT @IDOut AS ID,'Saved Successfully' Message , convert(bit, @IsSuccess) as IsSuccess
		END
 
 END 

 Else IF ( @ID >0 )
 
 BEGIN 
	IF(@Password = '' or @Password is null)
	BEGIN
		UPDATE User_T 
			 SET Name = @Name, 
			 Email = @Email, 
			 Designation = @Designation,
			 UserTypeAttributeID = @UserTypeAttributeID,
			 UserSectionID = @UserSectionID,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 

			SET @IdOut = @ID
			SET @IsSuccess = 1
			SELECT @IDOut AS ID,'Updated Successfully' Message , convert(bit, @IsSuccess) as IsSuccess 
	END

END 

COMMIT TRANSACTION

 END TRY
 BEGIN CATCH
 ROLLBACK TRANSACTION

	DECLARE @ErrorNumber_INT INT;
	DECLARE @ErrorSeverity_INT INT;
	DECLARE @ErrorProcedure_VC VARCHAR(200);
	DECLARE @ErrorLine_INT INT;
	DECLARE @ErrorMessage_NVC NVARCHAR(4000);
	SELECT
	@ErrorMessage_NVC = ERROR_MESSAGE(),
	@ErrorSeverity_INT = ERROR_SEVERITY(),
	@ErrorNumber_INT = ERROR_NUMBER(),
	@ErrorProcedure_VC = ERROR_PROCEDURE(),
	@ErrorLine_INT = ERROR_LINE()
	
	SET @IsSuccess = 0
	SELECT @IDOut AS ID,@ErrorMessage_NVC Message,@IsSuccess As IsSuccess

 RETURN
 END CATCH
 END
GO
/****** Object:  StoredProcedure [dbo].[Mob_CharacteristicsOpeningTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Mob_CharacteristicsOpeningTestDataById] 
	-- Add the parameters for the stored procedure here
	@TestId bigint
AS
BEGIN
	SELECT  CharacteristicsOpening.ID
      ,ParentID
      ,SpecimenID
      ,SpecimenWt
      ,ReceiverSieveWt
      ,ReceiverSieveWtWithBeads
      ,InitialBeadsWt
      ,SpecimenWtWithBeads
      ,SpecimenGraphImg
      ,StartMassForSieve
    , CharacteristicsOpeningChild.ID as ChildId
	, CharacteristicsOpeningChild.Sievemicron
	,CharacteristicsOpeningChild.SieveWt
	,CharacteristicsOpeningChild.SieveWtWithRetainedBeads
  FROM TD_Child_CharacteristicsOpening_T as CharacteristicsOpening with (nolock) inner join TD_Grand_Child_CharacteristicsOpening_T as CharacteristicsOpeningChild with (nolock)
  on CharacteristicsOpening.ID=CharacteristicsOpeningChild.ChildID where CharacteristicsOpening.ParentID=@TestId
END 
GO
/****** Object:  StoredProcedure [dbo].[Mob_GetTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_GetTestDataById]
	-- Add the parameters for the stored procedure here
	@UserId bigint,
	@OrderChildTestStandardID bigint
AS
BEGIN
	select  SampleCategory.Name as SampleCategoryName,SampleCategory.ID as SampleCategoryNameId,
SampleType.Name as SampleTypeName,SampleType.ID as SampleTypeNameId,TestName.Name as TestNameName,TestName.ID as TestNameId,
TestStandard.Name as TestStandardName , TestStandard.ID as TestStandardNameId,OrderChildSample.ID as OrderChildSampleId,
OrderChildTestStandard.ID as OrderChildTestStanderdID, OrderChildTestStandard.DeliveryDate as DeliveryDate,OrderParent.OrderDate
,case when isnull(TestParent.VerificationStatusAttributeID,0)=0 then 'Pending' when TestParent.VerificationStatusAttributeID=19 then 'Not Yet Submit' when TestParent.VerificationStatusAttributeID=21 then 'Return By Technical Manager' end as Status
,isnull(TestParent.ID,0)  As TestId
,isnull(TestParent.TemparatureFrom,0) as TemparatureFrom,isnull(TestParent.TemparatureTo,0) as TemparatureTo,isnull(TestParent.RelativeHumidityFrom,0) as RelativeHumidityFrom , isnull(TestParent.RelativeHumidityTo,0) as RelativeHumidityTo , isnull(TestParent.WaterTemperature,0) as WaterTemperature
,isnull(TestParent.ExposedSpecimenArea,0) as ExposedSpecimenArea ,isnull(TestParent.CorrectionFactor,0) as CorrectionFactor,isnull(TestParent.TechnicianID,0 ) as TechnicianID ,TestParent.TestDateTimeFrom,TestParent.TestDateTimeTo

from Test_Assign_T as TestAssign with (nolock) 
inner join Order_Child_Test_Standard_T as OrderChildTestStandard with (nolock) on TestAssign.OrderChildTestStanderdID=OrderChildTestStandard.ID
inner join Test_Standard_T as TestStandard with (nolock) on OrderChildTestStandard.TestStandardID=TestStandard.ID
inner join Test_Name_T as TestName with (nolock) on TestName.ID=TestStandard.TestNameID
inner join Order_Child_Sample_T as OrderChildSample with (nolock) on  OrderChildSample.ID=OrderChildTestStandard.SampleID
inner join Order_Parent_t as OrderParent with (nolock) on  OrderParent.Id=OrderChildSample.ParentID
inner join Sample_type_T as SampleType with (nolock) on SampleType.ID=OrderChildSample.SampleTypeID
inner join Sample_Category_T as SampleCategory with (nolock) on SampleCategory.ID=SampleType.SampleCategoryID
left join TD_Parent_T as TestParent with (nolock) on TestAssign.OrderChildTestStanderdID=TestParent.OrderChildTestStandardID 

where TestAssign.UserID=@UserId and OrderChildTestStandard.ID=@OrderChildTestStandardID
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_MachineList]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_MachineList] 
	
	@TestStandardId bigint
AS
BEGIN
	 select m.ID as MachineId, m.Name as MachineName, m.JawType, Att.ID as MachineTypeId, Att.Name as MachineTypeName,CONVERT(decimal(18,6),0) as CorrectionFactor, CONVERT(int,0) as CalibrationFrequencyInDays,CONVERT(int,0) as CalibrationFrequencyInTestNumber into #MachineT from Machine_T   as m with (nolock) inner join Attribute_T as Att with (nolock) on m.MachineTypeAttributeID=Att.ID
	 inner join Test_StandardVSMachine_T as TSVSM with (nolock) on m.ID=TSVSM.MachineID
	  where m.IsActive=1  and TSVSM.TestStandardID=@TestStandardId
	  select CF.MachineID, cf.CorrectionFactor, cf.CalibrationFrequencyInDays,CF.CalibrationFrequencyInTestNumber,max(cf.EffectiveDate) as EffectiveDate into #CalibrationFrequencyT
	  from #MachineT as MT inner join Calibration_Frequency_T as CF with (nolock) on mt.MachineId=cf.MachineID where CONVERT(date, EffectiveDate)<=CONVERT(date, GETDATE())
	  group by CF.MachineID, cf.CorrectionFactor, cf.CalibrationFrequencyInDays,CF.CalibrationFrequencyInTestNumber
	
update m set m.CorrectionFactor=c.CorrectionFactor, m.CalibrationFrequencyInDays=c.CalibrationFrequencyInDays
,m.CalibrationFrequencyInTestNumber=c.CalibrationFrequencyInTestNumber
 from #MachineT as M inner join #CalibrationFrequencyT as C on m.MachineId=c.MachineID
 select * from #MachineT

	  drop table #MachineT
	  drop table #CalibrationFrequencyT
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_MassPerUnitAreaTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_MassPerUnitAreaTestDataById] 
	@ParentId bigint=0
AS
BEGIN
	SELECT  [ID] as Id
      ,[ParentID] as TestId
      ,[SpecimenID] as SpecimenId
      ,[Weight]
      ,[SpecimenArea]
      
  FROM TD_Child_MassPerUnitArea_T as T with (nolock) where t.ParentID=@ParentId
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_StaticPunctureTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_StaticPunctureTestDataById] 
	-- Add the parameters for the stored procedure here
	@TestId bigint
AS
BEGIN
	SELECT  [ID] AS Id
      ,[ParentID]
      ,[SpecimenID]
      ,[ReadingSL]
      ,[ForceNewton]
      ,[Displacement]
      
  FROM TD_Child_StaticPuncture_T as Static with (nolock) where Static.ParentID=@TestId
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_TansileTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_TansileTestDataById] 
	-- Add the parameters for the stored procedure here
	@TestId bigint
AS
BEGIN
	SELECT  [ID]
     
      ,[ParentID]
      ,[SpecimenID]
      ,[SpecimenSL]
      ,[StrengthKnPerM]
      ,[ElongationPercent]
      ,[DirectionTypeID]
    
  FROM [DbMassData].[dbo].[TD_Child_Tansile_T] as Tansile with (nolock) where Tansile.ParentID=@TestId
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_TestDataEntryListByUser_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_TestDataEntryListByUser_SP] 
	-- Add the parameters for the stored procedure here
	@UserId bigint,
	@Status bigint=0
AS
BEGIN
	
select  SampleCategory.Name as SampleCategoryName,SampleCategory.ID as SampleCategoryNameId,
SampleType.Name as SampleTypeName,SampleType.ID as SampleTypeNameId,TestName.Name as TestNameName,TestName.ID as TestNameId,
TestStandard.Name as TestStandardName , TestStandard.ID as TestStandardNameId,OrderChildSample.ID as OrderChildSampleId,
OrderChildTestStandard.ID as OrderChildTestStanderdID, OrderChildTestStandard.DeliveryDate as DeliveryDate,OrderParent.OrderDate
,case when @Status=0 then 'Pending' when @Status=19 then 'Not Yet Submit' when @Status=21 then 'Return By Technical Manager' end as Status
from Test_Assign_T as TestAssign with (nolock) 
inner join Order_Child_Test_Standard_T as OrderChildTestStandard with (nolock) on TestAssign.OrderChildTestStanderdID=OrderChildTestStandard.ID
inner join Test_Standard_T as TestStandard with (nolock) on OrderChildTestStandard.TestStandardID=TestStandard.ID
inner join Test_Name_T as TestName with (nolock) on TestName.ID=TestStandard.TestNameID
inner join Order_Child_Sample_T as OrderChildSample with (nolock) on  OrderChildSample.ID=OrderChildTestStandard.SampleID
inner join Order_Parent_t as OrderParent with (nolock) on  OrderParent.Id=OrderChildSample.ParentID
inner join Sample_type_T as SampleType with (nolock) on SampleType.ID=OrderChildSample.SampleTypeID
inner join Sample_Category_T as SampleCategory with (nolock) on SampleCategory.ID=SampleType.SampleCategoryID
left join TD_Parent_T as TestParent with (nolock) on TestAssign.OrderChildTestStanderdID=TestParent.OrderChildTestStandardID 

where TestAssign.UserID=@UserId and isnull(TestParent.VerificationStatusAttributeID,0)=@Status



END
GO
/****** Object:  StoredProcedure [dbo].[Mob_TestDataEntryUserDashboard_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_TestDataEntryUserDashboard_SP] 
	-- Add the parameters for the stored procedure here
	@UserId bigint
AS
BEGIN
	declare @TestDataEntryPending int=0,@TestDataNotYetSubmit int=0, @ReturnByTechnicalManager int=0

select @TestDataEntryPending=count(TestAssign.OrderChildTestStanderdID)   from Test_Assign_T as TestAssign with (nolock) left join TD_Parent_T as TestParent with (nolock) on TestAssign.OrderChildTestStanderdID=TestParent.OrderChildTestStandardID where TestAssign.UserID=@UserId and TestParent.ID is null


select @TestDataNotYetSubmit= count(TestParent.OrderChildTestStandardID)  from Test_Assign_T as TestAssign with (nolock) inner join TD_Parent_T as TestParent with (nolock) on TestAssign.OrderChildTestStanderdID=TestParent.OrderChildTestStandardID where TestAssign.UserID=@UserId and TestParent.VerificationStatusAttributeID=19


select @ReturnByTechnicalManager= count(TestParent.OrderChildTestStandardID)  from Test_Assign_T as TestAssign with (nolock) inner join TD_Parent_T as TestParent with (nolock) on TestAssign.OrderChildTestStanderdID=TestParent.OrderChildTestStandardID where TestAssign.UserID=@UserId and TestParent.VerificationStatusAttributeID=21

select @TestDataEntryPending AS TestDataEntryPending, @ReturnByTechnicalManager as ReturnByTechnicalManager,@TestDataNotYetSubmit as TestDataNotYetSubmit
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_ThicknessTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_ThicknessTestDataById] 
	-- Add the parameters for the stored procedure here
	@TestId bigint
AS
BEGIN
	SELECT  [ID]
      ,[ParentID]
      ,[SpecimenID]
      ,[SpecimenSL]
      ,[ReadingSL]
   
      
  FROM [TD_Child_Thickness_Test_T] as ThicknessTest with (nolock) where ThicknessTest.ParentID=@TestId
END
GO
/****** Object:  StoredProcedure [dbo].[Mob_WaterPermeabilityTestDataById]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Mob_WaterPermeabilityTestDataById] 
	@ParentId bigint=0
AS
BEGIN
	SELECT [ID] as Id
     
      ,[ParentID] as TestId
      ,[SpecimenID] as SpecimenId
      ,[SpecimenSL]
      ,[SpecimenWt]
      ,[TimeSec]
      ,[PassedWaterVolume]
      
  FROM TD_Child_WaterPermeability_T as WaterPermeability with (nolock) where WaterPermeability.ParentID=@ParentId
END
GO
/****** Object:  StoredProcedure [dbo].[OrderEntrySearch]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[OrderEntrySearch]
(
	@OrderCode INT = 0,
	@CustomerID int = 0,
	@OrderDateFrom nvarchar(50) = '',
	@OrderDateTo nvarchar(50) ='',
	@DeliveryDateFrom nvarchar(50) ='',
	@DeliveryDateTo nvarchar(50) =''

)
as 
Begin 
   
	Select op.ID as OrderCode,
	op.GID 
	 ,op.ContactAddress As ContactAddress
	 ,op.ContactEmail As ContactEmail
	 ,op.ContactMobile As ContactMobile
	 ,op.ContactName As ContactName
	 ,op.CurrencyCode As CurrencyCode
	 ,op.CustomerID as CustomerID
	 ,cus.Name as CustomerName
	 ,op.DeliveryTypeAttributeID as  DeliveryTypeAttributeID
	 ,op.Description as Description
	 ,op.DiscountAmount as DiscountAmount
	
	 ,isnull(op.OrderDate,'') as  OrderDate
	 ,op.PaymentMode as  PaymentMode
	 ,op.ProjectID as  ProjectID
	-- ,isnull(oc.DeliveryDate,'') as DeliveryDate
	 ,sum(oc.UnitPrice) as TotalPrice
	 from Order_Parent_t  op 
	 inner join [Order_Child_Sample_T] as cs on op.ID = cs.ParentID
	 inner join Order_Child_Test_Standard_T as oc on cs.ID = oc.SampleID
	 inner join Customer_T as cus on     op.CustomerID = cus.ID 
	 where 
	 (op.ID = @OrderCode or @OrderCode = 0 )
	       and
	      ( op.CustomerID = @CustomerID or @CustomerID = 0 ) and
		  ( ( CONVERT(date, op.OrderDate) between convert( date,@OrderDateFrom) and CONVERT(date, @OrderDateTo)) or( @OrderDateFrom='' and @OrderDateTo='')) and
		  ( ( CONVERT(date, oc.DeliveryDate) between convert( date,@DeliveryDateFrom) and CONVERT(date, @DeliveryDateTo)) or (@DeliveryDateFrom='' and @DeliveryDateTo =''))

     group by op.ID,op.GID, op.ContactAddress, op.ContactEmail, op.ContactMobile, op.ContactName, op.CurrencyCode, op.CustomerID, cus.name,op.DeliveryTypeAttributeID ,op.Description, op.DiscountAmount, op.OrderDate, op.PaymentMode,op.ProjectID
		         
End
GO
/****** Object:  StoredProcedure [dbo].[PriceAgreementSearch_SP]    Script Date: 9/24/2023 8:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PriceAgreementSearch_SP 0,'','','',''
----Exec PriceAgreementSearch_SP 4,'2023-09-04','2023-09-04','2023-09-04',''
CREATE Procedure [dbo].[PriceAgreementSearch_SP] 
(
    @CustomerID bigint = 0,
    @AgreementFromDate nvarchar(50)='',
	@AgreementToDate nvarchar(50)='',
	@EffectiveFromDate nvarchar(50)='',
	@EffectiveToDate nvarchar(50)=''
)
As
BEGIN
     select PAP.ID AS ID,PAP.CustomerID,cust.Name As CustomerName,PAP.AgreementDate,PAP.EffectiveDateFrom,PAP.EffectiveDateTo,PAP.IsActive
	 from PriceAgreementParent_T as PAP with (nolock)
	 inner join Customer_T cust on PAP.CustomerID = cust.ID
	 where (PAP.CustomerID=@CustomerID or @CustomerID=0) 
	 and ( ( CONVERT(date, pap.AgreementDate) between convert( date,@AgreementFromDate) and CONVERT(date, @AgreementToDate)) or @AgreementFromDate='')
	 and (((CONVERT(date,pap.EffectiveDateFrom) >= Convert(date,@EffectiveFromDate) and CONVERT(date,pap.EffectiveDateTo) <= Convert(date,@EffectiveFromDate))
	 OR 
	 (Convert(date,pap.EffectiveDateFrom) >= Convert(date,@EffectiveToDate) and CONVERT(date,pap.EffectiveDateTo) <= CONVERT(date,@EffectiveToDate))) or @EffectiveFromDate='' )

END
GO
USE [DbMassData]
GO

/****** Object:  Table [dbo].[GlobalFileUrl]    Script Date: 9/27/2023 8:36:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GlobalFileUrl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ReferrenceNo] [varchar](500) NULL,
	[FileServerId] [varchar](500) NULL,
	[ReferenceDescription] [varchar](500) NULL,
	[DocumentTypeId] [bigint] NULL,
	[DocumentName] [varchar](500) NULL,
	[NumFileSize] [decimal](18, 3) NULL,
	[FileExtension] [varchar](500) NULL,
	[ServerLocation] [varchar](500) NULL,
	[IsActive] [bit] NULL,
	[Creator] [bigint] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Modifier] [bigint] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_GlobalFileUrl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [DbMassData]
GO

/****** Object:  Table [dbo].[Image]    Script Date: 9/27/2023 8:37:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Image](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[ImageName] [varchar](100) NULL,
	[ImageFile] [varchar](100) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [DbMassData]
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateGlobalFileUrl_SP]    Script Date: 9/27/2023 8:38:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----EXEC InsertUpdateGlobalFileUrl_SP 0,'013','FileServerId','rrr',0,'ddd','dd','FileExtension','ServerLocation',1,1 
ALTER Procedure [dbo].[InsertUpdateGlobalFileUrl_SP]
(
	@ID bigint,
	@ReferrenceNo varchar(500),
	@FileServerId varchar(500),
	@ReferenceDescription varchar(500),
	@DocumentTypeId bigint,
	@DocumentName varchar(500),
	@NumFileSize decimal(18,3),
	@FileExtension varchar(500), 
	@ServerLocation varchar(500),
    @IsActive bit,
    @Creator bigint
)

AS
BEGIN
	DECLARE @IDOut BIGINT
		,@Message VARCHAR(50),@IsSuccess bit

	BEGIN TRY
		BEGIN TRANSACTION 
		IF (@ID > 0)
		BEGIN  
		     UPDATE GlobalFileUrl 
			 SET ReferrenceNo = @ReferrenceNo,
			 FileServerId = @FileServerId,
			 ReferenceDescription = @ReferenceDescription,
			 DocumentTypeId = @DocumentTypeId,
			 DocumentName = @DocumentName,
			 NumFileSize = @NumFileSize,
			 FileExtension = @FileExtension, 
			 ServerLocation = @ServerLocation,
			 IsActive = @IsActive,
			 Modifier = @Creator,
			 ModificationDate = GETDATE()
			 WHERE ID = @ID 
			SET @IDOut = @ID
			set @IsSuccess=1
			SET @Message = 'Updated Successful'
		END
		ELSE
		BEGIN
			INSERT INTO GlobalFileUrl( 
				  ReferrenceNo,
				  FileServerId,
				  ReferenceDescription,
				  DocumentTypeId,
				  DocumentName,
				  NumFileSize,
				  FileExtension, 
				  ServerLocation,
				  IsActive,
				  Creator,
				  CreationDate
				)
			VALUES ( 
				@ReferrenceNo,
				@FileServerId,
				@ReferenceDescription,
				@DocumentTypeId,
				@DocumentName,
				@NumFileSize,
				@FileExtension, 
				@ServerLocation,
				@IsActive,
				@Creator,
				GETDATE()
				)

			SET @IDOut = SCOPE_IDENTITY()
					set @IsSuccess=1
			SET @Message = 'Save Successful'
		END 
		
		COMMIT TRANSACTION

		SELECT @IDOut AS ID
			,@Message AS Message , convert(bit, @IsSuccess) as IsSuccess
	END TRY

	BEGIN CATCH
		SELECT - 1 AS ID
			,ERROR_MESSAGE() AS Message,convert(bit, 0) as IsSuccess

		ROLLBACK TRANSACTION
	END CATCH
END 

GO
ALTER DATABASE [DbMassData] SET  READ_WRITE 
GO
USE [DbMassData]
GO
/****** Object:  StoredProcedure [dbo].[GetGlobalFileUrl_SP]    Script Date: 9/27/2023 8:34:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[GetGlobalFileUrl_SP]
(
   @ID bigint = 0
)
As
BEGIN
Select ID,ReferrenceNo,FileServerId,ReferenceDescription,DocumentTypeId,DocumentName,
NumFileSize,FileExtension,ServerLocation,IsActive from GlobalFileUrl Where ID = @ID OR @ID = 0
END 
GO
USE [DbMassData]
GO
/****** Object:  StoredProcedure [dbo].[DeleteGlobalFileUrl_SP]    Script Date: 9/27/2023 8:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[DeleteGlobalFileUrl_SP]
(
 @ID bigint
)
As 
BEGIN
   Delete From GlobalFileUrl Where ID = @ID 
END
