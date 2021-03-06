USE [master]
GO
/****** Object:  Database [TP4_DB]    Script Date: 22-Nov-21 5:53:52 PM ******/
CREATE DATABASE [TP4_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP4_DB', FILENAME = N'E:\Softwares\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TP4_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP4_DB_log', FILENAME = N'E:\Softwares\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TP4_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TP4_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP4_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP4_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP4_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP4_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP4_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP4_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP4_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP4_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP4_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP4_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP4_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP4_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP4_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP4_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP4_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP4_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP4_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP4_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP4_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP4_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP4_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP4_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP4_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP4_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [TP4_DB] SET  MULTI_USER 
GO
ALTER DATABASE [TP4_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP4_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP4_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP4_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP4_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TP4_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP4_DB', N'ON'
GO
ALTER DATABASE [TP4_DB] SET QUERY_STORE = OFF
GO
USE [TP4_DB]
GO
/****** Object:  Table [dbo].[JUGADOR_DE_VOLEY]    Script Date: 22-Nov-21 5:53:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JUGADOR_DE_VOLEY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nchar](50) NOT NULL,
	[APELLIDO] [nchar](50) NOT NULL,
	[ID_PAIS] [int] NOT NULL,
	[FECHA_NACIMIENTO] [date] NOT NULL,
	[PESO] [float] NOT NULL,
	[ALTURA] [float] NOT NULL,
	[ID_POSICION] [int] NOT NULL,
 CONSTRAINT [PK_JUGADOR_DE_VOLEY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAISES_DB]    Script Date: 22-Nov-21 5:53:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAISES_DB](
	[ID_PAIS] [int] NOT NULL,
	[PAIS] [nchar](50) NULL,
 CONSTRAINT [PK_PAISES_DB] PRIMARY KEY CLUSTERED 
(
	[ID_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POSICIONES_DB]    Script Date: 22-Nov-21 5:53:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSICIONES_DB](
	[ID_POSICION] [int] NOT NULL,
	[POSICION] [nchar](20) NULL,
 CONSTRAINT [PK_POSICIONES_DB] PRIMARY KEY CLUSTERED 
(
	[ID_POSICION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[JUGADOR_DE_VOLEY] ON 

INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1057, N'nahuel                                            ', N'murakoshi                                         ', 1, CAST(N'2000-06-23' AS Date), 55, 1.6, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1058, N'lautaro                                           ', N'matinez                                           ', 8, CAST(N'1997-11-03' AS Date), 78, 1.78, 4)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1059, N'leandro                                           ', N'murakoshi                                         ', 1, CAST(N'2000-08-18' AS Date), 65, 1.7, 1)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1060, N'julian                                            ', N'alvarez                                           ', 0, CAST(N'1999-03-16' AS Date), 76, 1.78, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1061, N'yuki                                              ', N'ishikawa                                          ', 6, CAST(N'2021-11-07' AS Date), 45, 1.7, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1062, N'yuuji                                             ', N'nishida                                           ', 6, CAST(N'2000-11-07' AS Date), 67, 1.86, 1)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1063, N'makoto                                            ', N'sakihara                                          ', 0, CAST(N'2003-03-24' AS Date), 67, 1.7, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1071, N'lucas                                             ', N'murakoshi                                         ', 0, CAST(N'2000-12-04' AS Date), 45, 1.5, 4)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1072, N'mariano                                           ', N'perez                                             ', 2, CAST(N'1999-04-22' AS Date), 57, 1.67, 4)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1073, N'ezequiel                                          ', N'shinzato                                          ', 0, CAST(N'2021-11-07' AS Date), 54, 2, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1074, N'ervin                                             ', N'ngapeth                                           ', 3, CAST(N'1994-11-07' AS Date), 76, 1.89, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1075, N'bruno                                             ', N'dececco                                           ', 0, CAST(N'1990-11-01' AS Date), 76, 1.87, 4)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1076, N'bruno                                             ', N'lima                                              ', 0, CAST(N'1993-02-07' AS Date), 87, 1.98, 1)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1077, N'jun                                               ', N'mizutani                                          ', 6, CAST(N'2003-03-04' AS Date), 65, 1.65, 3)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1078, N'douglas                                           ', N'costa                                             ', 7, CAST(N'1997-03-02' AS Date), 87, 1.98, 2)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1079, N'mariano                                           ', N'camapbel                                          ', 4, CAST(N'2000-03-05' AS Date), 78, 1.82, 0)
INSERT [dbo].[JUGADOR_DE_VOLEY] ([ID], [NOMBRE], [APELLIDO], [ID_PAIS], [FECHA_NACIMIENTO], [PESO], [ALTURA], [ID_POSICION]) VALUES (1080, N'gordon                                            ', N'mixwell                                           ', 8, CAST(N'1990-05-04' AS Date), 98, 2.2, 2)
SET IDENTITY_INSERT [dbo].[JUGADOR_DE_VOLEY] OFF
GO
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (0, N'Argentina                                         ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (1, N'Brasil                                            ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (2, N'EEUU                                              ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (3, N'Francia                                           ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (4, N'Iran                                              ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (5, N'Italia                                            ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (6, N'Japon                                             ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (7, N'Polonia                                           ')
INSERT [dbo].[PAISES_DB] ([ID_PAIS], [PAIS]) VALUES (8, N'Rusia                                             ')
GO
INSERT [dbo].[POSICIONES_DB] ([ID_POSICION], [POSICION]) VALUES (0, N'Punta               ')
INSERT [dbo].[POSICIONES_DB] ([ID_POSICION], [POSICION]) VALUES (1, N'Opuesto             ')
INSERT [dbo].[POSICIONES_DB] ([ID_POSICION], [POSICION]) VALUES (2, N'Central             ')
INSERT [dbo].[POSICIONES_DB] ([ID_POSICION], [POSICION]) VALUES (3, N'Libero              ')
INSERT [dbo].[POSICIONES_DB] ([ID_POSICION], [POSICION]) VALUES (4, N'Armador             ')
GO
ALTER TABLE [dbo].[JUGADOR_DE_VOLEY]  WITH CHECK ADD  CONSTRAINT [FK_JUGADOR_DE_VOLEY_PAISES_DB] FOREIGN KEY([ID_PAIS])
REFERENCES [dbo].[PAISES_DB] ([ID_PAIS])
GO
ALTER TABLE [dbo].[JUGADOR_DE_VOLEY] CHECK CONSTRAINT [FK_JUGADOR_DE_VOLEY_PAISES_DB]
GO
ALTER TABLE [dbo].[JUGADOR_DE_VOLEY]  WITH CHECK ADD  CONSTRAINT [FK_JUGADOR_DE_VOLEY_POSICIONES_DB] FOREIGN KEY([ID_POSICION])
REFERENCES [dbo].[POSICIONES_DB] ([ID_POSICION])
GO
ALTER TABLE [dbo].[JUGADOR_DE_VOLEY] CHECK CONSTRAINT [FK_JUGADOR_DE_VOLEY_POSICIONES_DB]
GO
USE [master]
GO
ALTER DATABASE [TP4_DB] SET  READ_WRITE 
GO
