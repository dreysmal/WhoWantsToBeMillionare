USE [master]
GO
/****** Object:  Database [MillionareDB]    Script Date: 22-Apr-18 16:39:02 ******/
CREATE DATABASE [MillionareDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MillionareDB', FILENAME = N'C:\Users\User\source\repos\Who_Wants_to_Become_a_Millionare_DBFIRST_ENTITYFRAMEWORK\MillionareDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MillionareDB_log', FILENAME = N'C:\Users\User\source\repos\Who_Wants_to_Become_a_Millionare_DBFIRST_ENTITYFRAMEWORK\MillionareDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MillionareDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MillionareDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MillionareDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MillionareDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MillionareDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MillionareDB] SET ARITHABORT ON 
GO
ALTER DATABASE [MillionareDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MillionareDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MillionareDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MillionareDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MillionareDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MillionareDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MillionareDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MillionareDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MillionareDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MillionareDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MillionareDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MillionareDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MillionareDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MillionareDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MillionareDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MillionareDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MillionareDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MillionareDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MillionareDB] SET  MULTI_USER 
GO
ALTER DATABASE [MillionareDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MillionareDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MillionareDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MillionareDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MillionareDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MillionareDB]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 22-Apr-18 16:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Questions_FK] [int] NOT NULL,
	[Answer_A] [nvarchar](255) NOT NULL,
	[Answer_B] [nvarchar](255) NOT NULL,
	[Answer_C] [nvarchar](255) NOT NULL,
	[Answer_D] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 22-Apr-18 16:39:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Difficulty] [int] NOT NULL,
	[Question] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (1, 1, N'Лежбище
', N'Стойбище
', N'Пастбище
', N'Гульбище
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (2, 2, N'Железная леди
', N'Стальная леди
', N'Оловянный солдатик
', N'Крепкий орешек
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (3, 3, N'Каир
', N'Токио
', N'Мадрид
', N'Сан-Франциско
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (4, 4, N'Гринвич
', N'Гринсборо
', N'Глазго
', N'Гронинген
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (5, 5, N'Киви
', N'Жако
', N'Эму
', N'Казуар
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (6, 6, N'Ричард I
', N'Вильгельм I
', N'Георг I
', N'Генрих I
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (7, 7, N'Пирамиды
', N'Гробницы
', N'Захоронения
', N'Сфинксы
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (8, 8, N'Медаль "Золотая Звезда"
', N'Медаль "За отвагу"
', N'Орден Суворова
', N'Орден мужества
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (9, 10, N'Зальцбург
', N'Веймар
', N'Прага
', N'Вена
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (10, 11, N'Рубикон
', N'Припять
', N'Нил
', N'Евфрат
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (11, 12, N'Икебана
', N'Суши
', N'Кэндо
', N'Харакири
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (12, 13, N'Бразилия
', N'Венесуэла
', N'Мексика
', N'Аргентина
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (13, 14, N'Вязать лыко
', N'Трепать нервы
', N'Бить баклуши
', N'Витать в облаках
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (14, 32, N'Якудза
', N'Джакузи
', N'Камикадзе
', N'Коза Ностра
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (15, 15, N'Биатлон
', N'Бейсбол
', N'Бадминтон
', N'Бобслей
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (16, 16, N'Торонто
', N'Оттава
', N'Ванкувер
', N'Монреаль
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (17, 18, N'Триумфальная арка
', N'Фиеста
', N'По ком звонит колокол
', N'Острова в океане
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (18, 19, N'Теннис
', N'Бокс
', N'Метание ядра
', N'Охота на лис
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (19, 20, N'Свидетели
', N'Соучастники
', N'Запасные
', N'Защитники
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (20, 21, N'Мерседес
', N'Тойота
', N'Хонда
', N'Лада
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (21, 22, N'Фиолетовый
', N'Коричневый
', N'Зеленый
', N'Голубой
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (22, 23, N'Фиат
', N'Феррари
', N'Ламборгини
', N'Альфа Ромео
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (23, 24, N'Диоген
', N'Демокрит
', N'Платон
', N'Сократ
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (24, 25, N'Гроза
', N'Снегопад
', N'Шаровая молния
', N'Гололед
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (25, 26, N'Синий
', N'Утренний
', N'Сиреневый
', N'Желтый
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (26, 27, N'Лермонтов
', N'Пушкин
', N'Нострадамус
', N'Некрасов
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (27, 28, N'Камуфляж
', N'Макияж
', N'Хаки
', N'Камуфлет
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (28, 29, N'Евразия
', N'Северная Америка
', N'Австралия
', N'Южная Америка
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (29, 30, N'Волга
', N'Победа
', N'Иномарки
', N'Жигули
')
INSERT [dbo].[Answers] ([Id],  [Questions_FK], [Answer_A], [Answer_B], [Answer_C], [Answer_D]) VALUES (1003, 31, N'Сделать сегодня', N'Сделать послезавтра', N'Сделать через месяц', N'Ничего не делать')
SET IDENTITY_INSERT [dbo].[Answers] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (1, 1, N'Как называется место на берегу, где обитают тюлени?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (2, 1, N'Как мировая пресса называла премьер-министра Великобритании Маргарет Тэтчер?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (3, 3, N'Какой из этих городов южнее остальных?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (4, 2, N'Через какой город мира проходит нулевой меридиан?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (5, 3, N'Какая птица является символом Новой Зеландии?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (6, 2, N'Какого короля англичане прозвали "Львиное сердце"?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (7, 1, N'Как в народе называются финансовые институты,  обещающие вкладчикам золотые горы?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (8, 2, N'Какая награда вручается вместе с присвоением звания Героя России?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (10, 3, N'В каком городе родился Вольфганг Амадей Моцарт?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (11, 2, N'Какую реку Юлий Цезарь перешел со словами "Жребий брошен"?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (12, 1, N'Как называется искусство аранжировки цветов?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (13, 3, N'Какая страна является мировым лидером по производству кофе?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (14, 1, N'Что труднее всего дается не трезвому человеку?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (15, 1, N'Участник какого из перечисленных спортивных состязаний экипирован винтовкой?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (16, 2, N'В каком канадском городе находится самая высокая в мире телебашня?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (18, 3, N'Какой из этих романов написал не Хемингуэй?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (19, 3, N'В каком виде спорта прославился Евгений Кафельников?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (20, 1, N'Как называется пара,  присутствующая на церемонии бракосочетания вместе с молодыми?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (21, 1, N'Как звали невесту Эдмона Дантеса,  будущего графа Монте-Кристо?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (22, 2, N'Какой цвет получается при смешении синего и красного?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (23, 3, N'Какая компания в Италии выпускает наибольшее количество автомобилей?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (24, 2, N'Кто из древних философов,  по преданию,  жил в бочке?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (25, 2, N'Каким из этих природных явлений А.Островский назвал свою пьесу?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (26, 1, N'Какой туман кажется В.Добрынину похожим на обман в одной из его песен?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (27, 3, N'Кому принадлежат строки - пророчества: "Настанет год,  России черный год,  Когда царей корона упадет..."?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (28, 1, N'Как называется маскировочная окраска военной техники и обмундирования?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (29, 3, N'Какой материк омывается всеми четырьмя океанами?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (30, 1, N'Какие машины предпочитал угонять Юрий Деточкин?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (31, 1, N'Как правильно закончить пословицу: «Не откладывай на завтра то, что можно…»?')
INSERT [dbo].[Questions] ([Id],  [Difficulty], [Question]) VALUES (32, 1, N'Как называют японских мафиози?')
SET IDENTITY_INSERT [dbo].[Questions] OFF
ALTER TABLE [dbo].[Answers]  WITH NOCHECK ADD FOREIGN KEY([Questions_FK])
REFERENCES [dbo].[Questions] ([Id])
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD CHECK  (([Difficulty]>(0) AND [Difficulty]<(4)))
GO
USE [master]
GO
ALTER DATABASE [MillionareDB] SET  READ_WRITE 
GO
