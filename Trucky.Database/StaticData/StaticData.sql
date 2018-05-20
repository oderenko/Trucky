INSERT INTO Truck
  VALUES ('Мерседес 609', 150, 100, 100, 125, NULL)
		,('MUDAN MD 1044', 160, 300, 1000, 160, NULL)
		,('КАМАЗ 45144', 200, 450, 450, 130, GETUTCDATE());

INSERT INTO Customer
  VALUES ('Jhon ORelly', 12345678, 'a@bc.de', 1, 1)
		,('Margaret Willson', 4629371, 'my@email.ru', 1, 1)
		,('Oleksandr Derenko', 987654, 'example@gmail.com', 0, 2)
		,('Greg Doe', 7835353, 'mega@mail.ru',1,2)
		,('Scarlet Johanson', 353512, 'scarlet@bingo.com', 0,1)

INSERT INTO Employee
  VALUES ('Amanda','Jaine', '1975-02-11', '2016-01-01', 5000, 'Lviv', 4)
		,('Ron','Wizzly', '1975-03-11', '2016-01-01', 7000, 'Lviv', 3)
		,('Adam','Lamberg', '1975-04-11', '2016-01-01', 7000, 'Ternopil', 3)
		,('Artur','Pirozhkov', '1975-05-11', '2016-03-01', 5000, 'Lviv', 1)
		,('Oleh','Scala', '1975-7-11', '2016-003-01', 5000, 'Lviv', 1)

INSERT INTO Cargo (Name, Volume, Price, IsComodity, IsFragile)
  VALUES ('Чай' ,         100,   12,    1,          0)
		,('Кава' ,        100,   15,    1,          0)
		,('Кава' ,        200,   29,    1,          0)
		,( 'Цукор' ,      1000,  10,    1,          0)
		,('Вино' ,        750,   15,    1,          1)
		,('Сніг',         1000,  2,     0,          0)
		,('Мусор' ,       1000,  4,     0,          0)
		,('Грунт' ,       1000,  1,     0,          0)
		,('Пшениця',      1000,  20,    1,          0)
		,('Банани' ,      100,   30,    1,          0)
		,('Пиво Пляшкове',500,   10,    1,          0)
		,('Пиво Скло' ,   500,   12,    1,          1)

INSERT INTO Goods
	VALUES   (1000, 1)
			,(1000, 2)
			,(1500, 3)
			,(2000, 4)
			,(700, 5)
			,(300, 6)

INSERT INTO Transportation
	VALUES ('2017-02-01', '2017-01-01', 1)
		  ,('2017-03-01', '2017-02-01', 2)
		  ,('2017-04-01', '2017-03-01', 3)
		  ,('2017-05-01', '2017-04-01', 1)
		  ,('2017-06-01', '2017-05-01', 2)