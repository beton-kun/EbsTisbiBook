using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EbsTisbiBook.WebAppMVC.Models;
using EbsTisbiBook.WebAppMVC.Models.Library;
using System.Diagnostics;
using EbsTisbiBook.WebAppMVC.Controllers.Admin;

namespace EbsTisbiBook.WebAppMVC.Models.Infrastucture
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<LibraryContext>();
            //context.Database.EnsureDeleted();

            //if (context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.Migrate();
            //}

            if (context.Books.Any()
                || context.Authors.Any()
                || context.Fgos.Any()
                || context.Languages.Any()
                || context.Pubhouses.Any()
                || context.Pubtypes.Any()
                || context.SpecialPurposes.Any()
                || context.Ugnp.Any())
            {
                Debug.WriteLine("Невозможно сгенерировать данные: базе данных уже существуют записи.");
                return;
            }

            context.Authors.AddRange(
                new Author()
                {
                    Surname = "Берлин",
                    Name = "Александр",
                    Middlename = "Николаевич",
                },
                new Author()
                {
                    Surname = "Третьяков",
                    Name = "Николай",
                    Middlename = "Николаевич",
                },
                new Author()
                {
                    Surname = "Ягодин",
                    Name = "Борис",
                    Middlename = "Александрович",
                },
                new Author()
                {
                    Surname = "Бабаева",
                    Name = "Елена",
                    Middlename = "Юрьевна",
                },
                new Author()
                {
                    Surname = "Туляков",
                    Name = "Александр",
                    Middlename = "Михайлович",
                },
                new Author()
                {
                    Surname = "Дубенок",
                    Name = "Никита",
                    Middlename = "Николаевич",
                },
                new Author()
                {
                    Surname = "Михалев",
                    Name = "Савелий",
                    Middlename = "Сергеевич",
                },
                new Author()
                {
                    Surname = "Ванюшин",
                    Name = "Дмитрий",
                    Middlename = "Сергеевич",
                }
                );
            context.SaveChanges();

            context.Ugnp.AddRange(
                new Ugnp()
                {
                    Name = "01 Математика и механика"
                },
                new Ugnp()
                {
                    Name = "02 Компьютерные и информационные науки"
                },
                new Ugnp()
                {
                    Name = "03 Физика и астрономия"
                }
                );
            context.SaveChanges();

            context.Fgos.AddRange(
                new Fgos()
                {
                    Name = "Математика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "01 Математика и механика")
                },
                new Fgos()
                {
                    Name = "Прикладная математика и информатика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "01 Математика и механика")
                },
                new Fgos()
                {
                    Name = "Механика и математическое моделирование",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "01 Математика и механика")
                },
                new Fgos()
                {
                    Name = "Прикладная математика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "01 Математика и механика")
                },
                new Fgos()
                {
                    Name = "Статистика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "01 Математика и механика")
                },
                new Fgos()
                {
                    Name = "Математика и компьютерные науки",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "02 Компьютерные и информационные науки")
                },
                new Fgos()
                {
                    Name = "Фундаментальная информатика и информационные технологии",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "02 Компьютерные и информационные науки")
                },
                new Fgos()
                {
                    Name = "Математическое обеспечение и администрирование информационных систем",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "02 Компьютерные и информационные науки")
                },
                new Fgos()
                {
                    Name = "Прикладные математика и физика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "03 Физика и астрономия")
                },
                new Fgos()
                {
                    Name = "Физика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "03 Физика и астрономия")
                },
                new Fgos()
                {
                    Name = "Радиофизика",
                    Ugnp = context.Ugnp.FirstOrDefault(u => u.Name == "03 Физика и астрономия")
                });
            context.SaveChanges();

            context.Languages.AddRange(
                new Language()
                {
                    Name = "Русский"
                },
                new Language()
                {
                    Name = "Английский"
                },
                new Language()
                {
                    Name = "Татарский"
                });
            context.SaveChanges();

            context.Pubhouses.AddRange(
                new Pubhouse()
                {
                    Name = "Интернет-Университет Информационных Технологий (ИНТУИТ)"
                },
                new Pubhouse()
                {
                    Name = "Профобразование"
                },
                new Pubhouse()
                {
                    Name = "Антология"
                },
                new Pubhouse()
                {
                    Name = "Квадро"
                },
                new Pubhouse()
                {
                    Name = "Троицкий мост"
                },
                new Pubhouse()
                {
                    Name = "Вузовское образование"
                });
            context.SaveChanges();

            context.Pubtypes.AddRange(
                new Pubtype()
                {
                    Name = "Учебное пособие"
                },
                new Pubtype()
                {
                    Name = "Научная публикация"
                },
                new Pubtype()
                {
                    Name = "Монография"
                },
                new Pubtype()
                {
                    Name = "Методическое пособие"
                });
            context.SaveChanges();

            context.SpecialPurposes.AddRange(
                new SpecialPurpose()
                {
                    Name = "ВУЗ"
                },
                new SpecialPurpose()
                {
                    Name = "СПО"
                });
            context.SaveChanges();

            context.Books.AddRange(
                new Book()
                {
                    Title = "Алгебра и теория чисел. Учебное пособие для СПО",
                    Pubyear = 2020,
                    Description = "В учебном пособии рассматриваются математическая теория, охватывающая первоначальные сведения об основных" +
                    " алгебраических структурах, теория матриц, определители и системы линейных уравнений, теория линейных и евклидовых пространств," +
                    " теория линейных операторов и квадратичных форм, теория делимости целых чисел, теория сравнений, а также приложение теории чисел " +
                    "к криптографии. В заключении пособия предлагаются теоретические вопросы для самоконтроля по каждой из глав, а также тесты практического " +
                    "содержания. Учебное пособие предназначено для изучения дисциплины «Математика: алгебра и начала математического анализа; геометрия» " +
                    "по всем профессиям и специальностям среднего профессионального образования.",
                    BibliographicRecord = "Сикорская Г.А. Алгебра и теория чисел [Электронный ресурс]: учебное пособие для СПО/ Сикорская" +
                    " Г.А.— Электрон. текстовые данные.— Саратов: Профобразование, 2020.— 303 c.— Режим доступа: http://www.iprbookshop.ru/91847.html.— ЭБС «IPRbooks»",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://iprbooks.ru/assets/images/covers/images/small/91847.jpg",
                    Isbn = "978-5-4488-0612-4",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Математика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Профобразование"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "СПО"),
                    Authors = new Author[1]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Берлин"
                        && f.Name == "Александр"
                        && f.Middlename == "Николаевич")
                    }
                },
                new Book()
                {
                    Title = "Алгебра матриц и линейные пространства. Учебное пособие",
                    TitleAdditional = "3-е издание",
                    Pubyear = 2020,
                    Description = "В учебном пособии рассматриваются основные свойства алгебры матриц, определители и свойства линейных пространств." +
                    " Приводятся методы вычисления определителей, способы умножения матриц. Рассмотрена теорема Гамильтона-Кэли." +
                    " Даются базовые понятия проективной геометрии, собственных чисел и собственных векторов. По каждой теме приведены примеры решения задач," +
                    " а также предоставлены задачи для самостоятельного рассмотрения.",
                    BibliographicRecord = " Михалев А.В. Алгебра матриц и линейные пространства [Электронный ресурс]: учебное пособие/" +
                    " Михалев А.В., Михалев А.А.— Электрон. текстовые данные.— Москва, Саратов: Интернет-Университет Информационных" +
                    " Технологий (ИНТУИТ), Ай Пи Ар Медиа, 2020.— 145 c.— Режим доступа: http://www.iprbookshop.ru/89415.html.— ЭБС «IPRbooks»",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://iprbooks.ru/assets/images/intuit/small/Algebra_matriz_i_lineynie_prostranstva.jpg",
                    Isbn = "978-5-4497-0364-4",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Математика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Интернет-Университет Информационных Технологий (ИНТУИТ)"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[3]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Третьяков"
                        && f.Name == "Николай"
                        && f.Middlename == "Николаевич"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Ягодин"
                        && f.Name == "Борис"
                        && f.Middlename == "Александрович"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Бабаева"
                        && f.Name == "Елена"
                        && f.Middlename == "Юрьевна"),
                    }
                },
                new Book()
                {
                    Title = "Начертательная геометрия: учебное пособие. В 2 частях. Ч.1. Учебно-методическое пособие",
                    TitleAdditional = "2-е издание",
                    Liability = "ред. Вилентьев М.А.",
                    Pubyear = 2019,
                    Description = "Приводятся примеры решения задач по следующим разделам дисциплины (модуля) «Начертательная геометрия»:" +
                    " «Точка, прямая, плоскость»; «Способы преобразования проекций»; «Многогранные поверхности и поверхности вращения»;" +
                    " «Аксонометрия». Предназначено для студентов первого курса направления подготовки 07.03.01. Архитектура, направленность " +
                    "(профиль) «Архитектурное проектирование», «Градостроительное проектирование» очной формы обучения.",
                    BibliographicRecord = "Прошунина, К. А. Начертательная геометрия: учебное пособие. В 2 частях. Ч.1 : учебно-методическое пособие /" +
                    " К. А. Прошунина. — Астрахань : Астраханский государственный архитектурно-строительный университет, ЭБС АСВ, 2019. — 149 c." +
                    " — ISBN 978-5-93026-089-2. — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]." +
                    " — URL: https://www.iprbookshop.ru/100834.html (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/covers/images/small/100834.jpg",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Математика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Антология"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[3]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Туляков"
                        && f.Name == "Александр"
                        && f.Middlename == "Михайлович"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Ягодин"
                        && f.Name == "Борис"
                        && f.Middlename == "Александрович"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Михалев"
                        && f.Name == "Савелий"
                        && f.Middlename == "Сергеевич"),
                    }
                },
                new Book()
                {
                    Title = "Типовой расчет по математическому анализу для направления «Прикладная математика и информатика». 1 модуль. Учебно-методическое пособие",
                    Pubyear = 2015,
                    Description = "Предлагаемое пособие предназначено для студентов первого курса по направлению подготовки 01.03.02 «Прикладная математика и информатика».",
                    BibliographicRecord = "Родина, Т. В. Типовой расчет по математическому анализу для направления «Прикладная математика и информатика»." +
                    " 1 модуль : учебно-методическое пособие / Т. В. Родина, Е. С. Трифанова, А. А. Бойцев. — Санкт-Петербург : Университет ИТМО, 2015." +
                    " — 43 c. — ISBN 2227-8397. — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]. — URL:" +
                    " https://www.iprbookshop.ru/65308.html (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/itmo/Tipovoy_raschet_po_matematicheskomu_analizu._1_modul.jpg",
                    Isbn = "",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Прикладная математика и информатика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Вузовское образование"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Методическое пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[3]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Дубенок"
                        && f.Name == "Никита"
                        && f.Middlename == "Николаевич"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Михалев"
                        && f.Name == "Савелий"
                        && f.Middlename == "Сергеевич"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Бабаева"
                        && f.Name == "Елена"
                        && f.Middlename == "Юрьевна"),
                    }
                },
                new Book()
                {
                    Title = "Задачи и упражнения по математическому анализу I (для специальности «Прикладная математика и информатика»). Учебное пособие",
                    Liability = "ред. Попов И.Ю.",
                    Pubyear = 2011,
                    Description = "Предлагаемое пособие предназначено для студентов ЕНФ и ФИТИП специальности «Прикладная математика и информатика»." +
                    " В пособии представлены задачи по математическому анализу, соответствующие курсу лекций, читаемых для студентов этой специальности " +
                    "в первом семестре. В начале каждого параграфа дан подробный разбор методов решения приводимых в пособии задач. Пособие может быть " +
                    "использовано студентами других специальностей, желающими углубить свои знания в области математического анализа.",
                    BibliographicRecord = "Родина, Т. В. Задачи и упражнения по математическому анализу I (для специальности «Прикладная математика и информатика»)" +
                    " : учебное пособие / Т. В. Родина, Е. С. Трифанова ; под редакцией И. Ю. Попов. — Санкт-Петербург : Университет ИТМО, 2011. — 211 c. — ISBN 2227-8397." +
                    " — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]. — URL: https://www.iprbookshop.ru/66444.html (дата обращения: 22.05.2021)." +
                    " — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/itmo/Zadachi_i_uprajzneniya_po_matematicheskomu_analizu.jpg",
                    Isbn = "",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Прикладная математика и информатика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Квадро"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[1]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Дубенок"
                        && f.Name == "Никита"
                        && f.Middlename == "Николаевич")
                    }
                },
                new Book()
                {
                    Title = "Статистика международных валютно-финансовых операций (статистика ВФО). Учебное пособие",
                    Liability = "ред. Попов И.Ю.",
                    Pubyear = 2004,
                    Description = "Целью курса является содействие всем российским субъектам осуществлению ими валютно-финансовых операций с" +
                    " зарубежными партнерами на единых принципах национального счетоводства. Курс предназначен для овладения студентами " +
                    "важнейших положений порядка регистрации статистикой таких операций между юридическими и физическими лицами в их международных" +
                    " операциях. Задачами этого курса являются следующие: – ознакомить студентов с предметом, содержанием и методами построения системы " +
                    "показателей, характеризующих эти операции, – описать статистические характеристики валютно-финансовых операций, – познакомить с" +
                    " особенностями валютных операций в России, – раскрыть особенности построения финансового счета в СНС, – выявить взаимосвязи" +
                    " показателей валютно-финансовых операций с показателями других счетов СНС.",
                    BibliographicRecord = "Нестеров, Л. И. Статистика международных валютно-финансовых операций (статистика ВФО) : учебное пособие /" +
                    " Л. И. Нестеров. — Москва : Евразийский открытый институт, Московский государственный университет экономики, статистики и информатики," +
                    " 2004. — 80 c. — ISBN 5-7764-0448-7. — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]." +
                    " — URL: https://www.iprbookshop.ru/10841.html (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/65.05/5-7764-0448-7.jpg",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Статистика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Квадро"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[1]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Ягодин"
                        && f.Name == "Борис"
                        && f.Middlename == "Александрович")
                    }
                },
                new Book()
                {
                    Title = "Демография и статистика населения. Сборник задач для бакалавров, получающих образование по направлению «Экономика», профиль подготовки «Статистика»",
                    TitleAdditional = "5-е издание",
                    Liability = "ред. Попов И.Ю.",
                    Pubyear = 2013,
                    Description = "Сборник задач подготовлен в соответствии с требованиями образовательного стандарта по дисциплине " +
                    "«Демография и статистика населения». Тематика задач охватывает статистическое изучение численности, состава и " +
                    "размещения населения, его естественного движения, естественного прироста и воспроизводства, миграционного движения," +
                    " демографического прогнозирования численности и статистической оценки демографической ситуации в регионах. Задачи сборника" +
                    " предназначены для решения на семинарских занятиях, а также для самостоятельной работы студентов. Для бакалавров, получающих" +
                    " образование по направлению «Экономика», профиль подготовки «Статистика». Может использоваться студентами других специальностей" +
                    " при изучении социальной статистики, демографии и статистики населения.",
                    BibliographicRecord = "Демография и статистика населения : сборник задач для бакалавров, получающих образование по направлению" +
                    " «Экономика», профиль подготовки «Статистика» / составители В. В. Нарбут. — Москва : Логос, 2013. — 92 c. — ISBN 978-5-98704-741-5." +
                    " — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]. — URL: https://www.iprbookshop.ru/21883.html" +
                    " (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/logos/978-5-98704-741-5.jpg",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Статистика"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Троицкий мост"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "СПО"),
                    Authors = new Author[2]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Бабаева"
                        && f.Name == "Елена"
                        && f.Middlename == "Юрьевна"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Ванюшин"
                        && f.Name == "Дмитрий"
                        && f.Middlename == "Сергеевич")
                    }
                },
                new Book()
                {
                    Title = "Математика, механика и компьютерные науки: подготовка к вступительным экзаменам в магистратуру. Задачник",
                    TitleAdditional = "5-е издание",
                    Liability = "ред. Коврижных А.Ю.",
                    Pubyear = 2018,
                    Description = "Даются задачи вступительных экзаменов в магистратуру департамента математики, механики и компьютерных наук с 2011 по 2015 г." +
                    " Часть задач снабжена решениями. Приводятся перечень вопросов и рекомендуемая литература для подготовки к экзаменам. Для студентов," +
                    " обучающихся по укрупненным группам направлений 010000 «Математика и механика», 020000 «Компьютерные и информационные науки»," +
                    " 090000 «Информатика и вычислительная техника».",
                    BibliographicRecord = "Математика, механика и компьютерные науки: подготовка к вступительным экзаменам в магистратуру : задачник " +
                    "/ Д. С. Ананичев, В. В. Арестов, М. О. Асанов [и др.] ; под редакцией А. Ю. Коврижных. — Екатеринбург : Издательство Уральского университета," +
                    " 2018. — 140 c. — ISBN 978-5-7996-2456-9. — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]. — URL:" +
                    " https://www.iprbookshop.ru/107054.html (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/20200608/books/1/978-5-7996-2456-9.jpg",
                    Isbn = "",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Математика и компьютерные науки"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Троицкий мост"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[2]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Берлин"
                        && f.Name == "Александр"
                        && f.Middlename == "Николаевич"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Ванюшин"
                        && f.Name == "Дмитрий"
                        && f.Middlename == "Сергеевич")
                    }
                },
                new Book()
                {
                    Title = "Информатика и информационные технологии. Учебное пособие",
                    Pubyear = 2012,
                    BibliographicRecord = "Цветкова, А. В. Информатика и информационные технологии : учебное пособие / А. В. Цветкова." +
                    " — Саратов : Научная книга, 2012. — 189 c. — ISBN 2227-8397. — Текст : электронный // Электронно-библиотечная система IPR BOOKS" +
                    " : [сайт]. — URL: https://www.iprbookshop.ru/6276.html (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",
                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/32.97/Informatika_i_informacionnye_texnologii._Uchebnoe_posobie.jpg",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Фундаментальная информатика и информационные технологии"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Троицкий мост"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Учебное пособие"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "ВУЗ"),
                    Authors = new Author[2]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Туляков"
                        && f.Name == "Александр"
                        && f.Middlename == "Михайлович"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Ягодин"
                        && f.Name == "Борис"
                        && f.Middlename == "Александрович")
                    }
                },
                new Book()
                {
                    Title = "Информационное обеспечение автоматизированных библиотечно-информационных систем. Учебник для студентов направления подготовки «Библиотечно-информационная " +
                    "деятельность», профиль подготовки «Технология автоматизированных библиотечно-информационных систем», квалификация (степень) «бакалавр»",
                    TitleAdditional = "6-е издание",
                    Pubyear = 2018,
                    Description = "Учебник содержит систематизированные знания по учебной дисциплине «Информационное обеспечение АБИС»," +
                    " которая относится к числу дисциплин, формирующих базовые компетенции студентов, обучающихся по направлению подготовки" +
                    " «Библиотечно-информационная деятельность», профиль подготовки «Технология автоматизированных библиотечно-информационных систем»," +
                    " квалификация (степень) «бакалавр». Учебник отражает весь комплекс вопросов, связанных с созданием и эксплуатацией информационного " +
                    "обеспечения АБИС. Особое место в учебнике уделено рассмотрению технологий создания электронных информационных ресурсов различных видов" +
                    " (баз данных, электронных коллекций документов, электронных справочных документов, официальных сайтов) как важнейших компонентов машинной" +
                    " информационной базы АБИС. Учебник предназначен студентам направления подготовки «Библиотечно-информационная деятельность», " +
                    "профиль подготовки «Технология автоматизированных библиотечно-информационных систем», квалификация «бакалавр»; может быть использован " +
                    "и студентами смежных направлений подготовки, а также магистрантами, аспирантами и преподавателями вузов культуры; работниками библиотек" +
                    " и других информационных учреждений.",

                    BibliographicRecord = "Математика, механика и компьютерные науки: подготовка к вступительным экзаменам в магистратуру : задачник " +
                    "/ Д. С. Ананичев, В. В. Арестов, М. О. Асанов [и др.] ; под редакцией А. Ю. Коврижных. — Екатеринбург : Издательство Уральского университета," +
                    " 2018. — 140 c. — ISBN 978-5-7996-2456-9. — Текст : электронный // Электронно-библиотечная система IPR BOOKS : [сайт]. — URL:" +
                    " https://www.iprbookshop.ru/107054.html (дата обращения: 22.05.2021). — Режим доступа: для авторизир. пользователей",

                    Url = "https://cloud.mail.ru/public/7JPe/TeiL13P8B",
                    Image = "https://www.iprbookshop.ru/assets/images/kguki/978-5-8154-0419-9.jpg",
                    Fgos = context.Fgos.FirstOrDefault(f => f.Name == "Математическое обеспечение и администрирование информационных систем"),
                    Language = context.Languages.FirstOrDefault(f => f.Name == "Русский"),
                    Pubhouse = context.Pubhouses.FirstOrDefault(f => f.Name == "Интернет-Университет Информационных Технологий (ИНТУИТ)"),
                    Pubtype = context.Pubtypes.FirstOrDefault(f => f.Name == "Монография"),
                    SpecialPurpose = context.SpecialPurposes.FirstOrDefault(f => f.Name == "СПО"),
                    Authors = new Author[4]
                    {
                        context.Authors.FirstOrDefault(f => f.Surname == "Берлин"
                        && f.Name == "Александр"
                        && f.Middlename == "Николаевич"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Третьяков"
                        && f.Name == "Николай"
                        && f.Middlename == "Николаевич"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Бабаева"
                        && f.Name == "Елена"
                        && f.Middlename == "Юрьевна"),
                        context.Authors.FirstOrDefault(f => f.Surname == "Туляков"
                        && f.Name == "Александр"
                        && f.Middlename == "Михайлович")
                    }
                }
                );
            context.SaveChanges();

              
            
        }
    }
}
