use [gdc]
go

insert into [Member] (mID, mPass, mName) values ('root','1234','������');
insert into [Member] (mID, mPass, mName) values ('gudi','1234','����');

insert into [Rule] (rName, rDesc) values ('����','');
insert into [Rule] (rName, rDesc) values ('�л�','');

insert into [Mapping] values (1, 1);
insert into [Mapping] values (2, 1);
insert into [Mapping] values (2, 2);

select * from [Member];
select * from [Rule];
select * from [Mapping];
