create database WebServices_Lab06;

use WebServices_Lab06;

create table [Student]
(
    id bigint primary key identity,
    name nvarchar(256) unique not null
);

create table [Note]
(
    id bigint primary key identity,
	studentId bigint foreign key references [Student] (id) not null,
    subj nvarchar(256) not null,
    note int not null,
);

