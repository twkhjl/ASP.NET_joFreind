CREATE TABLE [dbo].[admin](
	[adminID] [int] IDENTITY(1,1) NOT NULL,
	[account] [nvarchar](50) NULL,
	[password] [nvarchar](max) NULL,
	[status] [int] NULL CONSTRAINT [DF_admin_status]  DEFAULT ((0)),
	[authority] [int] NULL CONSTRAINT [DF_admin_authority]  DEFAULT ((1)),
	[remember_token] [nvarchar](max) NULL,
	#[createAt] [datetime] NULL CONSTRAINT [DF_admin_createAt]  DEFAULT (getdate()),
	[createAt] [datetime] NULL,
	[updateAt] [datetime] NULL,

 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[adminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO