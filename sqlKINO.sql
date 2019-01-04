if exists (select 1
            from  sysindexes
           where  id    = object_id('Dvorana')
            and   name  = 'uporablja_fk'
            and   indid > 0
            and   indid < 255)
   drop index Dvorana.uporablja_fk
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Dvorana')
            and   name  = 'ima_fk'
            and   indid > 0
            and   indid < 255)
   drop index Dvorana.ima_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Dvorana')
            and   type = 'U')
   drop table Dvorana
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Film')
            and   name  = 'reziseral_fk'
            and   indid > 0
            and   indid < 255)
   drop index Film.reziseral_fk
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Film')
            and   name  = 'produciral_fk'
            and   indid > 0
            and   indid < 255)
   drop index Film.produciral_fk
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Film')
            and   name  = 'omejitev_fk'
            and   indid > 0
            and   indid < 255)
   drop index Film.omejitev_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Film')
            and   type = 'U')
   drop table Film
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Karta')
            and   name  = 'kupil_fk'
            and   indid > 0
            and   indid < 255)
   drop index Karta.kupil_fk
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Karta')
            and   name  = 'velja_za_predstavo_fk'
            and   indid > 0
            and   indid < 255)
   drop index Karta.velja_za_predstavo_fk
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Karta')
            and   name  = 'velja_fk'
            and   indid > 0
            and   indid < 255)
   drop index Karta.velja_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Karta')
            and   type = 'U')
   drop table Karta
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Kolosej')
            and   name  = 'nahaja_na_fk'
            and   indid > 0
            and   indid < 255)
   drop index Kolosej.nahaja_na_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Kolosej')
            and   type = 'U')
   drop table Kolosej
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Naslov')
            and   name  = 'nahaja_fk'
            and   indid > 0
            and   indid < 255)
   drop index Naslov.nahaja_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Naslov')
            and   type = 'U')
   drop table Naslov
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Osebje_Filma')
            and   type = 'U')
   drop table Osebje_Filma
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Poste')
            and   type = 'U')
   drop table Poste
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Predstava')
            and   name  = 'nahaja_v_fk'
            and   indid > 0
            and   indid < 255)
   drop index Predstava.nahaja_v_fk
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Predstava')
            and   name  = 'predvaja_fk'
            and   indid > 0
            and   indid < 255)
   drop index Predstava.predvaja_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Predstava')
            and   type = 'U')
   drop table Predstava
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Produkcijska_Zalozba')
            and   type = 'U')
   drop table Produkcijska_Zalozba
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Sedez')
            and   name  = 'v_dvorani_fk'
            and   indid > 0
            and   indid < 255)
   drop index Sedez.v_dvorani_fk
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sedez')
            and   type = 'U')
   drop table Sedez
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Starostna_Omejitev')
            and   type = 'U')
   drop table Starostna_Omejitev
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tehnologija')
            and   type = 'U')
   drop table Tehnologija
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Uporabnik')
            and   type = 'U')
   drop table Uporabnik
go

/*==============================================================*/
/* Table: Dvorana                                               */
/*==============================================================*/
create table Dvorana (
   ID_Dvorane           int              identity,
   ID_Kolosej           int              not null,
   ID_Tehnologije       int              not null,
   Ime                  varchar(256)         not null,
   St_Vrst              int                  not null,
   st_sedezov_na_vrsto  int                  not null,
   constraint PK_DVORANA primary key nonclustered (ID_Dvorane)
)
go

/*==============================================================*/
/* Index: ima_fk                                                */
/*==============================================================*/
create index ima_fk on Dvorana (
ID_Kolosej ASC
)
go

/*==============================================================*/
/* Index: uporablja_fk                                          */
/*==============================================================*/
create index uporablja_fk on Dvorana (
ID_Tehnologije ASC
)
go

/*==============================================================*/
/* Table: Film                                                  */
/*==============================================================*/
create table Film (
   ID_Film              int              identity,
   ID_Zalozba           int              not null,
   ID_Omejitve          int              not null,
   ID_Osebje_Filma      int              not null,
   Naslov               varchar(256)         not null,
   Leto                 int                  not null,
   Cas_trajanja         int                  not null,
   constraint PK_FILM primary key nonclustered (ID_Film)
)
go

/*==============================================================*/
/* Index: omejitev_fk                                           */
/*==============================================================*/
create index omejitev_fk on Film (
ID_Omejitve ASC
)
go

/*==============================================================*/
/* Index: produciral_fk                                         */
/*==============================================================*/
create index produciral_fk on Film (
ID_Zalozba ASC
)
go

/*==============================================================*/
/* Index: reziseral_fk                                          */
/*==============================================================*/
create index reziseral_fk on Film (
ID_Osebje_Filma ASC
)
go

/*==============================================================*/
/* Table: Karta                                                 */
/*==============================================================*/
create table Karta (
   ID_Sedeza            int              not null,
   ID_Film              int              not null,
   ID_Dvorane           int              not null,
   Cas_Zacetka          TIME(7)             not null,
   Cas_Konca            TIME(7)             not null,
   Datum                datetime             not null,
   username             varchar(256)         not null,
   Cena                 float                not null,
   constraint PK_KARTA primary key (ID_Sedeza, ID_Film, ID_Dvorane, Cas_Zacetka, Cas_Konca, Datum)
)
go

/*==============================================================*/
/* Index: velja_fk                                              */
/*==============================================================*/
create index velja_fk on Karta (
ID_Sedeza ASC
)
go

/*==============================================================*/
/* Index: velja_za_predstavo_fk                                 */
/*==============================================================*/
create index velja_za_predstavo_fk on Karta (
ID_Film ASC,
ID_Dvorane ASC,
Cas_Zacetka ASC,
Cas_Konca ASC,
Datum ASC
)
go

/*==============================================================*/
/* Index: kupil_fk                                              */
/*==============================================================*/
create index kupil_fk on Karta (
username ASC
)
go

/*==============================================================*/
/* Table: Kolosej                                               */
/*==============================================================*/
create table Kolosej (
   ID_Kolosej           int              identity,
   ID_Naslov            int              not null,
   Ime                  varchar(256)         not null,
   OwnerId              varchar(256)         null,
   constraint PK_KOLOSEJ primary key nonclustered (ID_Kolosej)
)
go

/*==============================================================*/
/* Index: nahaja_na_fk                                          */
/*==============================================================*/
create index nahaja_na_fk on Kolosej (
ID_Naslov ASC
)
go

/*==============================================================*/
/* Table: Naslov                                                */
/*==============================================================*/
create table Naslov (
   ID_Naslov            int              identity,
   St_Poste             int                  not null,
   Ulica                varchar(256)         not null,
   Hisna_St             int                  not null,
   constraint PK_NASLOV primary key nonclustered (ID_Naslov)
)
go

/*==============================================================*/
/* Index: nahaja_fk                                             */
/*==============================================================*/
create index nahaja_fk on Naslov (
St_Poste ASC
)
go

/*==============================================================*/
/* Table: Osebje_Filma                                          */
/*==============================================================*/
create table Osebje_Filma (
   ID_Osebje_Filma      int              identity,
   Ime                  varchar(256)         not null,
   constraint PK_OSEBJE_FILMA primary key nonclustered (ID_Osebje_Filma)
)
go

/*==============================================================*/
/* Table: Poste                                                 */
/*==============================================================*/
create table Poste (
   St_Poste             int                  not null,
   Kraj                 varchar(256)         not null,
   constraint PK_POSTE primary key nonclustered (St_Poste)
)
go

/*==============================================================*/
/* Table: Predstava                                             */
/*==============================================================*/
create table Predstava (
   ID_Film              int              not null,
   ID_Dvorane           int              not null,
   Cas_Zacetka          TIME(7)             not null,
   Cas_Konca            TIME(7)             not null,
   Datum                datetime             not null,
   constraint PK_PREDSTAVA primary key nonclustered (ID_Film, ID_Dvorane, Cas_Zacetka, Cas_Konca, Datum)
)
go

/*==============================================================*/
/* Index: predvaja_fk                                           */
/*==============================================================*/
create index predvaja_fk on Predstava (
ID_Film ASC
)
go

/*==============================================================*/
/* Index: nahaja_v_fk                                           */
/*==============================================================*/
create index nahaja_v_fk on Predstava (
ID_Dvorane ASC
)
go

/*==============================================================*/
/* Table: Produkcijska_Zalozba                                  */
/*==============================================================*/
create table Produkcijska_Zalozba (
   ID_Zalozba           int              identity,
   Ime                  varchar(256)         not null,
   constraint PK_PRODUKCIJSKA_ZALOZBA primary key nonclustered (ID_Zalozba)
)
go

/*==============================================================*/
/* Table: Sedez                                                 */
/*==============================================================*/
create table Sedez (
   ID_Sedeza            int              identity,
   ID_Dvorane           int              not null,
   Vrsta                int                  not null,
   Stevilka             int                  not null,
   constraint PK_SEDEZ primary key nonclustered (ID_Sedeza)
)
go

/*==============================================================*/
/* Index: v_dvorani_fk                                          */
/*==============================================================*/
create index v_dvorani_fk on Sedez (
ID_Dvorane ASC
)
go

/*==============================================================*/
/* Table: Starostna_Omejitev                                    */
/*==============================================================*/
create table Starostna_Omejitev (
   ID_Omejitve          int              identity,
   Ime                  varchar(256)         not null,
   constraint PK_STAROSTNA_OMEJITEV primary key nonclustered (ID_Omejitve)
)
go

/*==============================================================*/
/* Table: Tehnologija                                           */
/*==============================================================*/
create table Tehnologija (
   ID_Tehnologije       int              identity,
   Ime_Tehnologije      varchar(256)         not null,
   constraint PK_TEHNOLOGIJA primary key nonclustered (ID_Tehnologije)
)
go

/*==============================================================*/
/* Table: Uporabnik                                             */
/*==============================================================*/
create table Uporabnik (
   username             varchar(256)         not null,
   password             varchar(256)         not null,
   constraint PK_UPORABNIK primary key nonclustered (username)
)
go
