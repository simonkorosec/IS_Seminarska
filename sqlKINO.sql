if exists (select 1
            from  sysindexes
           where  id    = object_id('Dvorana')
            and   name  = 'Uporablja_FK'
            and   indid > 0
            and   indid < 255)
   drop index Dvorana.Uporablja_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Dvorana')
            and   name  = 'Ima_FK'
            and   indid > 0
            and   indid < 255)
   drop index Dvorana.Ima_FK
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
            and   name  = 'Reziseral_FK'
            and   indid > 0
            and   indid < 255)
   drop index Film.Reziseral_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Film')
            and   name  = 'Produciral_FK'
            and   indid > 0
            and   indid < 255)
   drop index Film.Produciral_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Film')
            and   name  = 'Omejitev_FK'
            and   indid > 0
            and   indid < 255)
   drop index Film.Omejitev_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Film')
            and   type = 'U')
   drop table Film
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Igra_v')
            and   name  = 'Igra_v2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Igra_v.Igra_v2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Igra_v')
            and   name  = 'Igra_v_FK'
            and   indid > 0
            and   indid < 255)
   drop index Igra_v.Igra_v_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Igra_v')
            and   type = 'U')
   drop table Igra_v
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Karta')
            and   name  = 'Velja_za_predstavo_FK'
            and   indid > 0
            and   indid < 255)
   drop index Karta.Velja_za_predstavo_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Karta')
            and   name  = 'Velja za_FK'
            and   indid > 0
            and   indid < 255)
   drop index Karta."Velja za_FK"
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
            and   name  = 'Nahaja se na_FK'
            and   indid > 0
            and   indid < 255)
   drop index Kolosej."Nahaja se na_FK"
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
            and   name  = 'Nahaja v_FK'
            and   indid > 0
            and   indid < 255)
   drop index Naslov."Nahaja v_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Naslov')
            and   type = 'U')
   drop table Naslov
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Osebje Filma"')
            and   type = 'U')
   drop table "Osebje Filma"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Pozicija')
            and   type = 'U')
   drop table Pozicija
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
            and   name  = 'Nahaja_v_FK'
            and   indid > 0
            and   indid < 255)
   drop index Predstava.Nahaja_v_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Predstava')
            and   name  = 'Predvaja_FK'
            and   indid > 0
            and   indid < 255)
   drop index Predstava.Predvaja_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Predstava')
            and   type = 'U')
   drop table Predstava
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Pripada')
            and   name  = 'Pripada2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Pripada.Pripada2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Pripada')
            and   name  = 'Pripada_FK'
            and   indid > 0
            and   indid < 255)
   drop index Pripada.Pripada_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Pripada')
            and   type = 'U')
   drop table Pripada
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Produkcijska Zalozba"')
            and   type = 'U')
   drop table "Produkcijska Zalozba"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Sedez')
            and   name  = 'Se nahaja v_FK'
            and   indid > 0
            and   indid < 255)
   drop index Sedez."Se nahaja v_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sedez')
            and   type = 'U')
   drop table Sedez
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Starostna Omejitev"')
            and   type = 'U')
   drop table "Starostna Omejitev"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tehnologija')
            and   type = 'U')
   drop table Tehnologija
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Zaposleni')
            and   name  = 'Stanuje na_FK'
            and   indid > 0
            and   indid < 255)
   drop index Zaposleni."Stanuje na_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Zaposleni')
            and   name  = 'Zaposlen na_FK'
            and   indid > 0
            and   indid < 255)
   drop index Zaposleni."Zaposlen na_FK"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zaposleni')
            and   type = 'U')
   drop table Zaposleni
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zvrst')
            and   type = 'U')
   drop table Zvrst
go

/*==============================================================*/
/* Table: Dvorana                                               */
/*==============================================================*/
create table Dvorana (
   ID_Dvorane           numeric              identity,
   ID_Kolosej           numeric              not null,
   ID_Tehnologije       numeric              not null,
   Ime                  char(100)            not null,
   St_Vrst              decimal              not null,
   st_sedezov_na_vrsto  decimal              not null,
   constraint PK_DVORANA primary key nonclustered (ID_Dvorane)
)
go

/*==============================================================*/
/* Index: Ima_FK                                                */
/*==============================================================*/
create index Ima_FK on Dvorana (
ID_Kolosej ASC
)
go

/*==============================================================*/
/* Index: Uporablja_FK                                          */
/*==============================================================*/
create index Uporablja_FK on Dvorana (
ID_Tehnologije ASC
)
go

/*==============================================================*/
/* Table: Film                                                  */
/*==============================================================*/
create table Film (
   ID_Film              numeric              identity,
   ID_Zalozba           numeric              not null,
   ID_Omejitve          decimal              not null,
   ID_Osebje_Filma      numeric              not null,
   Naslov               char(256)            not null,
   Leto                 datetime             null,
   Cas_trajanja         datetime             null,
   constraint PK_FILM primary key nonclustered (ID_Film)
)
go

/*==============================================================*/
/* Index: Omejitev_FK                                           */
/*==============================================================*/
create index Omejitev_FK on Film (
ID_Omejitve ASC
)
go

/*==============================================================*/
/* Index: Produciral_FK                                         */
/*==============================================================*/
create index Produciral_FK on Film (
ID_Zalozba ASC
)
go

/*==============================================================*/
/* Index: Reziseral_FK                                          */
/*==============================================================*/
create index Reziseral_FK on Film (
ID_Osebje_Filma ASC
)
go

/*==============================================================*/
/* Table: Igra_v                                                */
/*==============================================================*/
create table Igra_v (
   ID_Film              numeric              not null,
   ID_Osebje_Filma      numeric              not null,
   constraint PK_IGRA_V primary key (ID_Film, ID_Osebje_Filma)
)
go

/*==============================================================*/
/* Index: Igra_v_FK                                             */
/*==============================================================*/
create index Igra_v_FK on Igra_v (
ID_Film ASC
)
go

/*==============================================================*/
/* Index: Igra_v2_FK                                            */
/*==============================================================*/
create index Igra_v2_FK on Igra_v (
ID_Osebje_Filma ASC
)
go

/*==============================================================*/
/* Table: Karta                                                 */
/*==============================================================*/
create table Karta (
   ID_Sedeza            numeric              not null,
   ID_Film              numeric              not null,
   ID_Dvorane           numeric              not null,
   Cas_Zacetka          datetime             not null,
   Cas_Konca            datetime             not null,
   Datum                datetime             not null,
   Cena                 float                null,
   constraint PK_KARTA primary key (ID_Sedeza, ID_Film, ID_Dvorane, Cas_Zacetka, Cas_Konca, Datum)
)
go

/*==============================================================*/
/* Index: "Velja za_FK"                                         */
/*==============================================================*/
create index "Velja za_FK" on Karta (
ID_Sedeza ASC
)
go

/*==============================================================*/
/* Index: Velja_za_predstavo_FK                                 */
/*==============================================================*/
create index Velja_za_predstavo_FK on Karta (
ID_Film ASC,
ID_Dvorane ASC,
Cas_Zacetka ASC,
Cas_Konca ASC,
Datum ASC
)
go

/*==============================================================*/
/* Table: Kolosej                                               */
/*==============================================================*/
create table Kolosej (
   ID_Kolosej           numeric              identity,
   ID_Naslov            numeric              not null,
   Ime                  char(100)            not null,
   constraint PK_KOLOSEJ primary key nonclustered (ID_Kolosej)
)
go

/*==============================================================*/
/* Index: "Nahaja se na_FK"                                     */
/*==============================================================*/
create index "Nahaja se na_FK" on Kolosej (
ID_Naslov ASC
)
go

/*==============================================================*/
/* Table: Naslov                                                */
/*==============================================================*/
create table Naslov (
   ID_Naslov            numeric              identity,
   St_Poste             int                  not null,
   Ulica                char(256)            not null,
   "Hisna St."          decimal              not null,
   constraint PK_NASLOV primary key nonclustered (ID_Naslov)
)
go

/*==============================================================*/
/* Index: "Nahaja v_FK"                                         */
/*==============================================================*/
create index "Nahaja v_FK" on Naslov (
St_Poste ASC
)
go

/*==============================================================*/
/* Table: "Osebje Filma"                                        */
/*==============================================================*/
create table "Osebje Filma" (
   ID_Osebje_Filma      numeric              identity,
   Ime                  char(100)            not null,
   "Datum Rojstva"      datetime             not null,
   constraint "PK_OSEBJE FILMA" primary key nonclustered (ID_Osebje_Filma)
)
go

/*==============================================================*/
/* Table: Pozicija                                              */
/*==============================================================*/
create table Pozicija (
   ID_Pozicije          numeric              identity,
   Ime_Pozicije         char(256)            not null,
   constraint PK_POZICIJA primary key nonclustered (ID_Pozicije)
)
go

/*==============================================================*/
/* Table: Poste                                                 */
/*==============================================================*/
create table Poste (
   St_Poste             int                  not null,
   Kraj                 char(256)            not null,
   constraint PK_POSTE primary key nonclustered (St_Poste)
)
go

/*==============================================================*/
/* Table: Predstava                                             */
/*==============================================================*/
create table Predstava (
   ID_Film              numeric              not null,
   ID_Dvorane           numeric              not null,
   Cas_Zacetka          datetime             not null,
   Cas_Konca            datetime             not null,
   Datum                datetime             not null,
   constraint PK_PREDSTAVA primary key nonclustered (ID_Film, ID_Dvorane, Cas_Zacetka, Cas_Konca, Datum)
)
go

/*==============================================================*/
/* Index: Predvaja_FK                                           */
/*==============================================================*/
create index Predvaja_FK on Predstava (
ID_Film ASC
)
go

/*==============================================================*/
/* Index: Nahaja_v_FK                                           */
/*==============================================================*/
create index Nahaja_v_FK on Predstava (
ID_Dvorane ASC
)
go

/*==============================================================*/
/* Table: Pripada                                               */
/*==============================================================*/
create table Pripada (
   ID_Zvrst             numeric              not null,
   ID_Film              numeric              not null,
   constraint PK_PRIPADA primary key (ID_Zvrst, ID_Film)
)
go

/*==============================================================*/
/* Index: Pripada_FK                                            */
/*==============================================================*/
create index Pripada_FK on Pripada (
ID_Zvrst ASC
)
go

/*==============================================================*/
/* Index: Pripada2_FK                                           */
/*==============================================================*/
create index Pripada2_FK on Pripada (
ID_Film ASC
)
go

/*==============================================================*/
/* Table: "Produkcijska Zalozba"                                */
/*==============================================================*/
create table "Produkcijska Zalozba" (
   ID_Zalozba           numeric              identity,
   Ime                  char(100)            not null,
   constraint "PK_PRODUKCIJSKA ZALOZBA" primary key nonclustered (ID_Zalozba)
)
go

/*==============================================================*/
/* Table: Sedez                                                 */
/*==============================================================*/
create table Sedez (
   ID_Sedeza            numeric              identity,
   ID_Dvorane           numeric              not null,
   Vrsta                decimal              not null,
   Stevilka             decimal              not null,
   constraint PK_SEDEZ primary key nonclustered (ID_Sedeza)
)
go

/*==============================================================*/
/* Index: "Se nahaja v_FK"                                      */
/*==============================================================*/
create index "Se nahaja v_FK" on Sedez (
ID_Dvorane ASC
)
go

/*==============================================================*/
/* Table: "Starostna Omejitev"                                  */
/*==============================================================*/
create table "Starostna Omejitev" (
   ID_Omejitve          decimal              not null,
   Ime                  char(100)            not null,
   constraint "PK_STAROSTNA OMEJITEV" primary key nonclustered (ID_Omejitve)
)
go

/*==============================================================*/
/* Table: Tehnologija                                           */
/*==============================================================*/
create table Tehnologija (
   ID_Tehnologije       numeric              identity,
   Ime_Tehnologije      char(256)            not null,
   constraint PK_TEHNOLOGIJA primary key nonclustered (ID_Tehnologije)
)
go

/*==============================================================*/
/* Table: Zaposleni                                             */
/*==============================================================*/
create table Zaposleni (
   ID_Zaposleni         numeric              identity,
   ID_Naslov            numeric              not null,
   ID_Pozicije          numeric              not null,
   Ime                  char(100)            not null,
   "Datum Rojstva"      datetime             not null,
   Urna_Postavka        float                null,
   constraint PK_ZAPOSLENI primary key nonclustered (ID_Zaposleni)
)
go

/*==============================================================*/
/* Index: "Zaposlen na_FK"                                      */
/*==============================================================*/
create index "Zaposlen na_FK" on Zaposleni (
ID_Pozicije ASC
)
go

/*==============================================================*/
/* Index: "Stanuje na_FK"                                       */
/*==============================================================*/
create index "Stanuje na_FK" on Zaposleni (
ID_Naslov ASC
)
go

/*==============================================================*/
/* Table: Zvrst                                                 */
/*==============================================================*/
create table Zvrst (
   ID_Zvrst             numeric              identity,
   Ime                  char(100)            not null,
   constraint PK_ZVRST primary key nonclustered (ID_Zvrst)
)
go
