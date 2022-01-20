CREATE TABLE tbl_urunler
(
Id INT IDENTITY(1,1) NOT NULL,
urunAd NVARCHAR(50)  NULL,
tedarikciId INT  NULL,
alisFiyat Decimal(7,2)  NULL,
satisFiyat Decimal(7,2)  NULL,
);
CREATE TABLE tbl_musteriler
(
Id INT IDENTITY(1,1) NOT NULL,
musteriAd NVARCHAR(50)  NULL,
musteriSoyad NVARCHAR(20)  NULL,
musteriAdres NVARCHAR(100)NULL,
musteriTel VARCHAR(12)  NULL,
musteriUrunId INT  NULL,
);
CREATE TABLE tbl_siparisler
(
Id INT IDENTITY(1,1) NOT NULL,
urunId NVARCHAR(50)  NULL,
musteriId INT  NULL,
tarih DATE NULL,
);
CREATE TABLE tbl_tedarikci
(
Id INT IDENTITY(1,1) NOT NULL,
tedarikciFirma NVARCHAR(50)  NULL,
tedarikciAdres NVARCHAR(100)  NULL,
tedarikciTel VARCHAR(12) NULL,
tedarikciMail NVARCHAR(50) NULL,
);


INSERT INTO tbl_urunler(urunAd,tedarikciId,alisFiyat,satisFiyat) VALUES 
('Beyaz Peynir',1,'10','15') 
INSERT INTO tbl_urunler(urunAd,tedarikciId,alisFiyat,satisFiyat) VALUES 
('Gofret',1,'1','2') 



INSERT INTO tbl_musteriler(musteriAd,musteriSoyad,musteriAdres,musteriTel,musteriUrunId) VALUES 
('Ali','Ak','kartal/ÝSTANBUL',05368459253,1) 
INSERT INTO tbl_musteriler(musteriAd,musteriSoyad,musteriAdres,musteriTel,musteriUrunId) VALUES 
('Veli','Baykal','Kadýköy/ÝSTANBUL',05632145896,2) 
INSERT INTO tbl_musteriler(musteriAd,musteriSoyad,musteriAdres,musteriTel,musteriUrunId) VALUES 
('Ayþe','Çýnar','Üsküdar/ÝSTANBUL',05362985417,3) 
INSERT INTO tbl_musteriler(musteriAd,musteriSoyad,musteriAdres,musteriTel,musteriUrunId) VALUES 
('Fatma','Aksoy','Pendik/ÝSTANBUL',05369852147,4) 
INSERT INTO tbl_musteriler(musteriAd,musteriSoyad,musteriAdres,musteriTel,musteriUrunId) VALUES 
('Sezen','Erol','Avcýlar/ÝSTANBUL',05398614785,5) 
INSERT INTO tbl_musteriler(musteriAd,musteriSoyad,musteriAdres,musteriTel,musteriUrunId) VALUES 
('Dilara','Özkul','Niþantaþý/ÝSTANBUL',05396682514,6) 


INSERT INTO tbl_siparisler(urunId,musteriId,tarih)VALUES 
(1,1,'20220118')
INSERT INTO tbl_siparisler(urunId,musteriId,tarih) VALUES 
(2,3,'20220118') 
INSERT INTO tbl_siparisler(urunId,musteriId,tarih) VALUES 
( 1,5,'20220117') 


INSERT INTO tbl_tedarikci(tedarikciFirma,tedarikciAdres,tedarikciTel,tedarikciMail) VALUES 
('NET GIDA LTD. ÞTI','teyfikbey mah. güneþ sit. c2 blok daire 5 sefaköy/ist',05356854786,'info@netgida.com.tr') 

INSERT INTO tbl_tedarikci(tedarikciFirma,tedarikciAdres,tedarikciTel,tedarikciMail) VALUES 
('NET GIDA LTD. ÞTI','hayaran cad. kemalettin sok. no=8/1 sultanahmet/ist',05369874521,'info@yaysat.com.tr') 


INSERT INTO tbl_tedarikci(tedarikciFirma,tedarikciAdres,tedarikciTel,tedarikciMail) VALUES 
( 'FORZA GIDA A.Þ.','salýk cad. kent apt. no=65/6 k.çekmece/ist',05536225874,'info@forza.com.tr') 

Select * from tbl_musteriler
Select * from tbl_siparisler
Select * from tbl_tedarikci
Select * from tbl_urunler