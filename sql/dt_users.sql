CREATE TABLE users (
userID int IDENTITY(1,1) PRIMARY KEY  NOT NULL,

email varchar(50) NULL,
mobile varchar(50) NULL,
password varchar(200) NULL,
registerMode int NULL default 0,
status int NULL default 0,
authority int NULL,
rememberToken varchar(200) NULL,

name varchar(50) NULL,
nickname varchar(120) NULL,
intro text NULL,
address varchar(50) NULL,
birthDate Datetime NULL,
gender int NULL,
imgUrl varchar(300) NULL,


createAt datetime NULL,
updateAt datetime NULL

)