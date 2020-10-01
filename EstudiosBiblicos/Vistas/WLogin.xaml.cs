using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WLogin : ContentPage
    {
        public WLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //agregar datos estaticos
            Curso c1 = new Curso() { IdCurso = 1, Nombre = "Cimiento Bíblico", Descripcion = "Todas las religiones cristianas tienen como marco de autoridad en mayor o menor medida a la Biblia.Esta obra especial es más que literatura, ciencia o historia.Es la revelación más completa que poseemos para poder conocer a Dios en la medida que él se nos ha revelado.Además, aquí están los cimientos que en este estudio deseo compartir contigo.", Duracion = 4, Estatus = 1, Lecciones = 7, Imagen = "cimientob" };
            Curso c2 = new Curso() { IdCurso = 2, Nombre = "Para Jóvenes", Descripcion = "Estudio bíblico para jóvenes", Duracion = 2, Estatus = 1, Lecciones = 4, Imagen = "curso2" };
            int a1 = App.Database.InsertarCurso(c1);
            int a2 = App.Database.InsertarCurso(c2);

            Leccion L1 = new Leccion() { IdCurso = 1, IdLeccion = 1, Nombre = "Las Escrituras"
                , Descripcion = "Todas las religiones cristianas tienen como marco de autoridad en mayor o menor medida a la Biblia. Esta obra especial es más que literatura, ciencia o historia. Es la revelación más completa que poseemos para poder conocer a Dios en la medida que él se nos ha revelado. Además, aquí están los cimientos que en este estudio deseo compartir contigo."
                , Duracion = 1, Estatus = 1, Correctas = 0, TiempoDurado = 0
                , Imagen = "L11"
                , Incorrectas = 0
                , Omitidas = 0
                , Preguntas = 7
                , Puntos = 0 };
            Leccion L2 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 2,
                Nombre = "Segunda Venida de Cristo"
                ,
                Descripcion = @"La primera venida de Jesús dividió la historia en dos.Pero su primer advenimiento fue la preparación para su segunda venida cuando establecerá para siempre su reino y viviremos junto a nuestro Salvador.Nuestros anhelos impulsados por el Espíritu Santo serán realizados, será el momento del mayor gozo y felicidad que hayamos experimentado.Pero también su venida será de dolor y llanto para aquellos que no esperaron su venida."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L22"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 10
                ,
                Puntos = 0
            };
            Leccion L3 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 3,
                Nombre = "El Santuario"
                ,
                Descripcion = @"En el principio, Dios optó por mostrar todo el plan de salvación a través de un símbolo: el santuario. La diversidad de acciones que se realizaban en este edificio ilustraba la forma en la que Jesús daría su vida por la salvación de todos nosotros. Hoy podemos ver como todas las verdades bíblicas giran en el contexto del santuario."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L33"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L4 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 4,
                Nombre = "La Salvación"
                ,
                Descripcion = @"El pecado arrebató de nosotros la inmortalidad y nos introdujo en la perdición. Ante este gran dilema humano Dios envió a su hijo Jesucristo en quien tenemos salvación por su sangre."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L44"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 9
                ,
                Puntos = 0
            };
            Leccion L5 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 5,
                Nombre = "El Gran Conflicto"
                ,
                Descripcion = @"Todos nos encontramos dentro de una batalla cósmica. Esta batalla es espiritual y no se pelea con los armamentos propios de las guerras actuales, necesitamos las armas espirituales que Dios tiene para cada uno de nosotros. Satanás quiere el control de nuestras mentes para destruirnos, y por otro lado Cristo desea que le permitamos entrar en nuestras vidas para junto a él seamos vencedores."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L55"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 9
                ,
                Puntos = 0
            };
            Leccion L6 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 6,
                Nombre = "La Ley de Dios y el Sábado"
                ,
                Descripcion = @"Todo gobierno se rige por leyes, no es menos en el reino de Dios. Su ley es justa, buena, adecuada para cada uno de nosotros. Es completa, está basada en el amor y el servicio. Estos principios están estipulados para que vivamos en un clima de amor y respeto, dando el lugar que Dios debe tener en nosotros y cómo debe ser nuestra relación con el prójimo. En el sábado, como uno de los mandamientos de la ley de Dios, podemos encontrar reposo y paz en un mundo convulso."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L66"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 11
                ,
                Puntos = 0
            };
            Leccion L7 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 7,
                Nombre = "La Muerte y Resurrección"
                ,
                Descripcion = @"Todo gobierno se rige por leyes, no es menos en el reino de Dios. Su ley es justa, buena, adecuada para cada uno de nosotros. Es completa, está basada en el amor y el servicio. Estos principios están estipulados para que vivamos en un clima de amor y respeto, dando el lugar que Dios debe tener en nosotros y cómo debe ser nuestra relación con el prójimo. En el sábado, como uno de los mandamientos de la ley de Dios, podemos encontrar reposo y paz en un mundo convulso."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L77"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 11
                ,
                Puntos = 0
            };
            Leccion L8 = new Leccion()
            {
                IdCurso = 1,
                IdLeccion = 8,
                Nombre = "Dones Espirituales"
                ,
                Descripcion = @"Todos los creyentes han sido dotados con dones espirituales para ser usados en la expansión del reino de Dios en la tierra. Estos dones bien usados son los regalos del Espíritu Santo a cada creyente, para la perfección de los santos, en este tiempo presente. La iglesia como un cuerpo está compuesta de una multiplicidad de órganos, cada uno realizando un papel fundamental en el todo del organismo. Somos parte de una iglesia con muchos dones que persiguen el mismo fin, la predicación del evangelio en todo el mundo."
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "L88"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };


            Leccion L9 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 9,
                Nombre = "Amigos de verdad"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L10 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 10,
                Nombre = "¿Con quién y cuándo debo Casarme?"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L11 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 11,
                Nombre = "El amor de Dios es más grande que nuestro pecado"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L12 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 12,
                Nombre = "Incitaciones letales"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L13 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 13,
                Nombre = "Aprovechando el tiempo"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L14 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 14,
                Nombre = "Una Carta de Amor"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L15 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 15,
                Nombre = "¿Dios Existe?"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L16 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 16,
                Nombre = "El precio de la Salvación"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L17 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 17,
                Nombre = "Nuestra más grande Esperanza"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            Leccion L18 = new Leccion()
            {
                IdCurso = 2,
                IdLeccion = 18,
                Nombre = "La Gran Decisión"
                ,
                Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia. 2 Timoteo 3:16"
                ,
                Duracion = 1,
                Estatus = 1,
                Correctas = 0,
                TiempoDurado = 0
                ,
                Imagen = "curso2"
                ,
                Incorrectas = 0
                ,
                Omitidas = 0
                ,
                Preguntas = 8
                ,
                Puntos = 0
            };
            App.Database.InsertarLeccion(L1);
            App.Database.InsertarLeccion(L2);
            App.Database.InsertarLeccion(L3);
            App.Database.InsertarLeccion(L4);
            App.Database.InsertarLeccion(L5);
            App.Database.InsertarLeccion(L6);
            App.Database.InsertarLeccion(L7);
            App.Database.InsertarLeccion(L8);
            App.Database.InsertarLeccion(L9);
            App.Database.InsertarLeccion(L10);
            App.Database.InsertarLeccion(L11);
            App.Database.InsertarLeccion(L12);
            App.Database.InsertarLeccion(L13);
            App.Database.InsertarLeccion(L14);
            App.Database.InsertarLeccion(L15);
            App.Database.InsertarLeccion(L16);
            App.Database.InsertarLeccion(L17);
            App.Database.InsertarLeccion(L18);

            Leccion1Sel ll1 = new Leccion1Sel() { IdLeccion = 1, S1 = false, S2 = false
                , S3 = false, Correctas = 0, Seleccionadas = 0 };
            Leccion2Sel ll2 = new Leccion2Sel()
            {
                IdLeccion = 2,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };
            Leccion3Sel ll3 = new Leccion3Sel()
            {
                IdLeccion = 3,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };
            Leccion4Sel ll4 = new Leccion4Sel()
            {
                IdLeccion = 4,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };
            Leccion5Sel ll5 = new Leccion5Sel()
            {
                IdLeccion = 5,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };
            Leccion6Sel ll6 = new Leccion6Sel()
            {
                IdLeccion = 6,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };
            Leccion7Sel ll7 = new Leccion7Sel()
            {
                IdLeccion = 6,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };
            Leccion8Sel ll8 = new Leccion8Sel()
            {
                IdLeccion = 8,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0
            };

            Leccion9Sel ll9 = new Leccion9Sel()
            {
                IdLeccion = 9,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "¿En qué consiste la verdadera amistad?",
                P2 = "¿El verdadero amigo siempre tiene una actitud de amigo y de hermano?",
                P3 = "¿Cómo se demuestra la amistad incondicional?",
                P4 = "¿Debemos estar más cerca de las influencia peligrosa?",
                P5 = "¿Existen los amigos por interés?",
                P6 = "¿Los amigos conflictivos y problemáticos le hacen bien a nuestra vida?",
                P7 = "¿Qué es capaz de hacer un amigo verdadero?",
                P8 = "¿Cómo nos considera Jesús?",
                P9 = "¿De qué manera se manifestó el gran amor de nuestro amigo Jesús?",
                P10 = "¿Cuál es el requisito para ser llamado Amigo de Dios?",
                TB1 = "Proverbios 17:17",
                TB2 = "Proverbios 18:24",
                TB3 = "Proverbios 14:20,21",
                TB4 = "Deuteronomio 13:6-8",
                TB5 = "Proverbios 19:6",
                TB6 = "Job 16:20",
                TB7 = "Juan 15: 13",
                TB8 = "Juan 15:15",
                TB9 = "Juan 3:16",
                TB10 = "Santiago 2:23"
            };
            Leccion9Sel ll10 = new Leccion9Sel()
            {
                IdLeccion = 10,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "Si, porque la juventud es la mejor epoca",
                T2 = "No, debemos orar y confiar",
                T3 = "Si y no",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Unirnos sin importar nuestas creencias",
                T7 = "La luz y las tinieblas hacen buen compañerismo",
                T8 = "No unirnos en yugo desigual",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "Debemos de ser humildes y cuidadosos al tomar una decision",
                T12 = "Indiferencia al decidir en el Amor",
                T13 = "Soberbia al decidir en el Amor",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Guardar nuestro dinero",
                T17 = "Guardar nuestros ojos",
                T18 = "Guardar nuestro corazon",
                T19 = "Jugar con la tentecion y la pasion",
                T20 = "Leer la biblia juntos",
                T21 = "Trabajar para Dios en la obra misionera",
                T22 = "El señor hara nuestra voluntad",
                T23 = "El señor escuchara nuestras peticiones",
                T24 = "Tendremos paz",
                T25 = "Con nuestra pareja",
                T26 = "Con nuestros padres",
                T27 = "Con nuestro Dios Todopoderoso",
                P1 = "¿Debe el joven apresurarse a tener una relación de noviazgo?",
                P2 = "¿El amor que podemos procesarle a otra persona deriva de Dios?",
                P3 = "¿Qué aconseja la Biblia en cuanto a la afinidad que debe existir entre la pareja?",
                P4 = "¿Dios nos dotó con libertad de elegir?",
                P5 = "A pesar de tener libertad de elección, ¿qué actitud debería manifestar el joven a la hora de tomar decisiones?",
                P6 = "¿El novio o la novia o futuro cónyuge debe manifestar bondad, fidelidad, humildad y control propio?",
                P7 = "¿Qué debe el joven guardar sobre todas las cosas?",
                P8 = "¿Qué debe evitar toda pareja de novios?",
                P9 = "Si nos deleitamos en Jehová, ¿qué pasará con los deseos de nuestro corazón?",
                P10 = "¿Cuál debe ser la relación amorosa más importante en la vida de todo joven?",
                TB1 = "Filipenses 4: 6",
                TB2 = "1 Juan 4: 8",
                TB3 = "2 Corintios 6: 14",
                TB4 = "Gálatas 5: 13",
                TB5 = "Génesis 24: 12",
                TB6 = "Gálatas 5: 22-23",
                TB7 = "Proverbios 4: 23",
                TB8 = "Proverbios 6:27-28",
                TB9 = "Salmos 37:4",
                TB10 = "Jeremías 31:3"
            };
            Leccion9Sel ll11 = new Leccion9Sel()
            {
                IdLeccion = 11,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "Lee Gálatas 5: 19-21 y menciona por lo menos seis de los pecados que perturban al hombre",
                P2 = "¿El consumo de alcohol trae beneficios a mi vida?",
                P3 = "¿Qué razones Bíblicas tenemos para afirmar que el consumo de cigarrillos es pecado?",
                P4 = "Lee Romanos 6: 23 ¿El precio del pecado es la muerte?",
                P5 = " ¿Nos esclaviza el pecado?",
                P6 = "¿Dios perdona y ayuda a quienes insisten en continuar bajo el yugo del pecado?",
                P7 = "¿Qué consejo recibimos de parte de Dios?",
                P8 = "¿Puede el hombre solucionar el problema del pecado?",
                P9 = "¿Quién es el único que puede solucionar entonces?",
                P10 = "Una vez liberado del pecado ¿cómo se debe actuar?",
                TB1 = "Gálatas 5: 19-21",
                TB2 = "Proverbios 23: 31-33",
                TB3 = "1 corintios 3: 16-17",
                TB4 = "Romanos 6: 23",
                TB5 = "San Juan 8: 34",
                TB6 = "Romanos 1: 24",
                TB7 = "Romanos 13: 13",
                TB8 = "Jeremías 2:22",
                TB9 = "Juan 1: 29",
                TB10 = "Gálatas 5:1"
            };
            Leccion9Sel ll12 = new Leccion9Sel()
            {
                IdLeccion = 12,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "¿De dónde proceden las tentaciones?",
                P2 = "¿Para caer en el pecado solo debemos ver?",
                P3 = "¿Es pecado la tentación?",
                P4 = "¿Ante la tentación debemos mostrar una Actitud de confianza?",
                P5 = "Si nos resistimos a pecar, ¿qué pasará con el diablo?",
                P6 = "¿Es posible vencer las tentaciones con el poder de Dios?",
                P7 = "¿Qué promesa nos hace Cristo ante la tentación?",
                P8 = "Cuando somos tentados, ¿qué espera Cristo de nosotros?",
                P9 = "¿Cuál es el resultado natural de no seguir el ejemplo de Cristo y caer en las tentaciones de satanás?",
                P10 = "¿Qué recompensa tendrán los que se mantengan fieles?",
                TB1 = "Santiago 1:13-14",
                TB2 = "Josué 7:21",
                TB3 = "Mateo 4: 1-6",
                TB4 = "Génesis 39:12",
                TB5 = "Santiago 4:7",
                TB6 = "Hebreos 4: 15",
                TB7 = "1 Corintios 10: 13",
                TB8 = "Juan 13: 15",
                TB9 = "Romanos 6:23",
                TB10 = "Santiago 1:12"
            };
            Leccion9Sel ll13 = new Leccion9Sel()
            {
                IdLeccion = 13,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "Lee Santiago 4:13-14 ¿A qué se compara nuestra vida terrenal?",
                P2 = "Según la Biblia ¿Tiene límites la existencia del hombre?",
                P3 = "¿Qué amenaza asecha nuestras vidas día tras día?",
                P4 = "¿Comprendía Jesús acerca del corto tiempo que le restaba en la tierra?",
                P5 = "¿En qué invirtió Jesús su tiempo mientras estuvo en la tierra?",
                P6 = "¿Los que no están dispuestos a trabajar deben comer?",
                P7 = "¿Qué invitación nos hace el Señor?",
                P8 = "¿Qué consejos encontramos en la Biblia a fin de aprovechar bien el tiempo?",
                P9 = "¿A quién le daremos cuenta por el tiempo vivido?",
                P10 = "¿A quién le daremos cuenta por el tiempo vivido?",
                TB1 = "Santiago 4:13-14",
                TB2 = "Job 14: 5",
                TB3 = "Romanos 5: 12",
                TB4 = "Juan 7: 33",
                TB5 = "Lucas 4: 18",
                TB6 = "2 Tesalonicenses 3:10",
                TB7 = "Colosenses 1: 10",
                TB8 = "Efesios 5:15-18",
                TB9 = "Eclesiastés 11:9",
                TB10 = "Eclesiastés 11:9"
            };
            Leccion9Sel ll14 = new Leccion9Sel()
            {
                IdLeccion = 14,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "¿Quién inspiró a los apóstoles y profetas de la Biblia?",
                P2 = "¿Las Escrituras nos dan esperanza y ánimo?",
                P3 = "Siendo que la Biblia fue copiada por escribas durante siglos, ¿Es aún digna de confianza? ¿Podemos realmente creer en ella?",
                P4 = "¿La biblia puede ser nuestra lampara y lumbrera en el camino?",
                P5 = "¿De quién dan testimonios las Escrituras?",
                P6 = "¿Desde la niñez y juventud se nos recomienda aprender de las escrituras?",
                P7 = "Señala los beneficios de leer la biblia",
                P8 = "¿Cómo pueden los jóvenes limpiar sus vidas de pecado?",
                P9 = "¿Qué sucederá en nuestras vidas al degustar la Palabra de Dios?",
                P10 = "¿Debemos meditar en su palabra solo en la Iglesia?",
                TB1 = "2 Pedro 1:21",
                TB2 = "Romanos 15: 4",
                TB3 = "Salmos 12: 6,7",
                TB4 = "Salmos 119: 105",
                TB5 = "San Juan 5: 39",
                TB6 = "2 Timoteo 3: 14 -15",
                TB7 = "2 Timoteo 3:16",
                TB8 = "Salmos 119: 9",
                TB9 = "Jeremías 15: 16",
                TB10 = "Salmos 63: 6"
            };
            Leccion9Sel ll15 = new Leccion9Sel()
            {
                IdLeccion = 15,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "¿Quién es Dios para la humanidad?",
                P2 = "¿Dios es el Rey del cielo y del universo?",
                P3 = "¿Cuál es el carácter del reinado de Dios sobre el universo?",
                P4 = "¿Tiene Dios alguna limitación?",
                P5 = "¿Puede el hombre acercarse al Dios del universo?",
                P6 = "¿Nos conoce Dios en forma personal?",
                P7 = "¿Realmente le importamos a Dios?",
                P8 = "¿Cuál ha sido el gran sueño de Dios para con la humanidad?",
                P9 = "¿Se cumplirá finalmente el sueño de Dios?",
                P10 = "¿Te gustaría a ti también hacer del Dios del universo el Dios de tu vida?",
                TB1 = "Génesis 1: 27",
                TB2 = "Salmos 24:7-10",
                TB3 = "Daniel 7:27",
                TB4 = "Marcos 10: 27",
                TB5 = "Juan 6: 37",
                TB6 = "Salmos 139:1-2",
                TB7 = "Salmos 121",
                TB8 = "Éxodo 25: 8",
                TB9 = "Apocalipsis 21:3",
                TB10 = "Deuteronomio 7:9"
            };
            Leccion9Sel ll16 = new Leccion9Sel()
            {
                IdLeccion = 16,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "¿Qué efecto tiene el pecado en la relación entre Dios y el hombre?",
                P2 = "¿La muerte es consecuencia del pecado?",
                P3 = "¿Quién originó la brecha en la relación Dios hombre?",
                P4 = "¿Mediante Cristo nos reconciliamos con Dios?",
                P5 = "¿Cuál es el único camino hacia la salvación?",
                P6 = "¿El cielo ofreció la redención y salvación del hombre?",
                P7 = "¿Qué movió a Cristo a morir por nosotros?",
                P8 = "¿A qué padecimientos se sometió Jesús?",
                P9 = "¿Cuál debe ser la respuesta de la humanidad ante el regalo de la salvación?",
                P10 = "¿Qué acto aseguro nuestra salvación?",
                TB1 = "Isaías 59: 2",
                TB2 = "Romanos 6:23",
                TB3 = "Génesis 3: 6",
                TB4 = "2 Corintios 5:19",
                TB5 = "Hechos 4: 12",
                TB6 = "Juan 3: 16",
                TB7 = "Romanos 5: 8",
                TB8 = "Isaías 53",
                TB9 = "Apocalipsis 3:20",
                TB10 = "1 Corintios 15:20-22"
            };
            Leccion9Sel ll17 = new Leccion9Sel()
            {
                IdLeccion = 17,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "No comentar nuestros errores",
                T2 = "Amar en todo tiempo",
                T3 = "Ser como un hermano en",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Siendo un amigos en los mejores momentos",
                T7 = "Ser traicionero con los amigos",
                T8 = "Amando al amigo en los momentos dificiles y en los buenos momentos",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "No existen",
                T12 = "Si existen",
                T13 = "No lo se",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "Cuidar de mi cuando enfermo",
                T17 = "Dar su vida por mi",
                T18 = "Asumir una deuda millonaria",
                T19 = "Siervos",
                T20 = "Hijos",
                T21 = "Amigos",
                T22 = "Dandonos poder",
                T23 = "Amandonos",
                T24 = "Muriendo por nosotros para regalarnos vida eterna",
                T25 = "Hacer sacrificios",
                T26 = "Creer en el",
                T27 = "Leer la Biblia",
                P1 = "¿Qué gran promesa nos hizo Jesús?",
                P2 = "¿Los apóstoles anhelaban la segunda venida de Cristo?",
                P3 = "Características de la conducta moral de la humanidad para el fin de los tiempos",
                P4 = "¿Se sabe exactamente cuándo vendrá Jesús?",
                P5 = "¿Qué señales predijo Jesús acerca de su venida?",
                P6 = "¿Estará dividida en grupos de personas la humanidad para cuando Cristo regrese?",
                P7 = "¿Qué clase de cuerpos recibirán los jóvenes redimidos?",
                P8 = "¿Cuál será el hogar de los jóvenes redimidos?",
                P9 = "¿Cuál será la condición de vida de los salvados?",
                P10 = "¿Para quiénes está reservada la vida eterna?",
                TB1 = "Juan 14:1-3",
                TB2 = "Apocalipsis 22:20",
                TB3 = "2 Timoteo 3:1-4",
                TB4 = "Mateo 24: 44",
                TB5 = "Mateo 24:3-14",
                TB6 = "Mateo 25:31-46",
                TB7 = "1 Corintios 15:53",
                TB8 = "Apocalipsis 21:1-2",
                TB9 = "Apocalipsis 21:4",
                TB10 = "Juan 3:16"
            };
            Leccion9Sel ll18 = new Leccion9Sel()
            {
                IdLeccion = 18,
                S1 = false,
                S2 = false,
                S3 = false,
                Correctas = 0,
                Seleccionadas = 0,
                T1 = "Decidir por la paz",
                T2 = "Decidir por su vida",
                T3 = "Decidir suervir y seguir a Dios",// tiempos de angustia",
                T4 = "Verdadero",
                T5 = "Falso",
                T6 = "Salvarnos por medio de Jesús",
                T7 = "Condearnos por medio de Jesús",
                T8 = "Hacer juicio con nosotros",
                T9 = "Verdadero",
                T10 = "Falso",
                T11 = "El de la vida",
                T12 = "El de las riquezas",
                T13 = "El de la comodidad",
                T14 = "Vedadero",
                T15 = "Falso",
                T16 = "En el futuro",
                T17 = "Mañana",
                T18 = "Hoy",
                T19 = "Muy poco",
                T20 = "Es indispensable",
                T21 = "No es importante",
                T22 = "La decision del bautismo",
                T23 = "Seguir pensando",
                T24 = "Seguir dudando",
                T25 = "Que abramos la puerta",
                T26 = "Que abramos el corazon",
                T27 = "Que abramos nuestra casa",
                P1 = "¿Qué decisión marcó la vida de Josué?",
                P2 = "¿Rut se alejo de su suegra?",
                P3 = "¿Qué clase de decisión ha tomado Dios respecto a nosotros?",
                P4 = "¿Deseas elegir la vida eterna?",
                P5 = "¿Qué camino nos aconseja Dios que tomemos?",
                P6 = "¿Debemos seguir indecisos ante el llamado de Dios?",
                P7 = "¿Cuándo debemos tomar la decisión de entregar nuestra vida a cristo?",
                P8 = "¿Cuán indispensable es el bautismo?",
                P9 = "¿Qué clase de llamado nos hace Dios?",
                P10 = "¿Qué otro tierno llamado hace Jesús?",
                TB1 = "Josué 24: 15",
                TB2 = "Rut 1: 16",
                TB3 = "2 Timoteo 1: 9",
                TB4 = "Deuteronomio 30: 15",
                TB5 = "Deuteronomio 30: 19",
                TB6 = "Joel 3: 14",
                TB7 = "Hebreos 4: 7",
                TB8 = "Marcos 16: 16",
                TB9 = "Hechos 22: 16",
                TB10 = "Apocalipsis 3:20"
            };

            App.Database.InsertarL1(ll1);
            App.Database.InsertarL2(ll2);
            App.Database.InsertarL3(ll3);
            App.Database.InsertarL4(ll4);
            App.Database.InsertarL5(ll5);
            App.Database.InsertarL6(ll6);
            App.Database.InsertarL7(ll7);
            App.Database.InsertarL9(ll9);
            App.Database.InsertarL9(ll10);
            App.Database.InsertarL9(ll11);
            App.Database.InsertarL9(ll12);
            App.Database.InsertarL9(ll13);
            App.Database.InsertarL9(ll14);
            App.Database.InsertarL9(ll15);
            App.Database.InsertarL9(ll16);
            App.Database.InsertarL9(ll17);
            App.Database.InsertarL9(ll18);

            TextoBiblico Tb1 = new TextoBiblico() { Id_Texto = 1, Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia," };
            TextoBiblico Tb2 = new TextoBiblico() { Id_Texto = 2, Descripcion = "Porque no hará nada Jehová el Señor, sin que revele su secreto a sus siervos los profetas." };
            TextoBiblico Tb3 = new TextoBiblico() { Id_Texto = 3, Descripcion = "Tenemos también la palabra profética más segura, a la cual hacéis bien en estar atentos como a una antorcha que alumbra en lugar oscuro, hasta que el día esclarezca y el lucero de la mañana salga en vuestros corazones." };
            TextoBiblico Tb4 = new TextoBiblico() { Id_Texto = 4, Descripcion = "Toda la Escritura es inspirada por Dios, y útil para enseñar, para redargüir, para corregir, para instruir en justicia." };
            TextoBiblico Tb5 = new TextoBiblico() { Id_Texto = 5, Descripcion = "Porque nunca la profecía fue traída por voluntad humana, sino que los santos hombres de Dios hablaron siendo inspirados por el Espíritu Santo." };
            TextoBiblico Tb6 = new TextoBiblico() { Id_Texto = 6, Descripcion = "A fin de que el hombre de Dios sea perfecto, enteramente preparado para toda buena obra." };
            TextoBiblico Tb7 = new TextoBiblico() { Id_Texto = 7, Descripcion = "Ten cuidado de ti mismo y de la doctrina; persiste en ello, pues haciendo esto, te salvarás a ti mismo y a los que te oyeren." };
            TextoBiblico Tb8 = new TextoBiblico() { Id_Texto = 8, Descripcion = "Lo cual también hablamos, no con palabras enseñadas por sabiduría humana, sino con las que enseña el Espíritu, acomodando lo espiritual a lo espiritual." };
            TextoBiblico Tb9 = new TextoBiblico() { Id_Texto = 9, Descripcion = "El que quiera hacer la voluntad de Dios, conocerá si la doctrina es de Dios, o si yo hablo por mi propia cuenta." };
            TextoBiblico Tb10 = new TextoBiblico() { Id_Texto = 10, Descripcion = "Tú guardarás en completa paz a aquel cuyo pensamiento en ti persevera; porque en ti ha confiado." };

            TextoBiblico Tb11 = new TextoBiblico() { Id_Texto = 11, Descripcion = "En todo tiempo ama el amigo, Y es como un hermano en tiempo de angustia." };
            TextoBiblico Tb12 = new TextoBiblico() { Id_Texto = 12, Descripcion = "El hombre que tiene amigos ha de mostrarse amigo; Y amigo hay más unido que un hermano." };
            TextoBiblico Tb13 = new TextoBiblico() { Id_Texto = 13, Descripcion = "El pobre es odioso aun a su amigo; Pero muchos son los que aman al rico. Peca el que menosprecia a su prójimo; Mas el que tiene misericordia de los pobres es bienaventurado." };
            TextoBiblico Tb14 = new TextoBiblico() { Id_Texto = 14, Descripcion = "Si te incitare tu hermano, hijo de tu madre, o tu hijo, tu hija, tu mujer o tu amigo íntimo, diciendo en secreto: Vamos y sirvamos a dioses ajenos, que ni tú ni tus padres conocisteis, de los dioses de los pueblos que están en vuestros alrededores, cerca de ti o lejos de ti, desde un extremo de la tierra hasta el otro extremo de ella; no consentirás con él, ni le prestarás oído; ni tu ojo le compadecerá, ni le tendrás misericordia, ni lo encubrirás" };
            TextoBiblico Tb15 = new TextoBiblico() { Id_Texto = 15, Descripcion = "Muchos buscan el favor del generoso, Y cada uno es amigo del hombre que da." };
            TextoBiblico Tb16 = new TextoBiblico() { Id_Texto = 16, Descripcion = "A fin de que el hombre de Dios sea perfecto, enteramente preparado para toda buena obra." };
            TextoBiblico Tb17 = new TextoBiblico() { Id_Texto = 17, Descripcion = "Disputadores son mis amigos; Mas ante Dios derramaré mis lágrimas." };
            TextoBiblico Tb18 = new TextoBiblico() { Id_Texto = 18, Descripcion = "Ya no os llamaré siervos, porque el siervo no sabe lo que hace su señor; pero os he llamado amigos, porque todas las cosas que oí de mi Padre, os las he dado a conocer." };
            TextoBiblico Tb19 = new TextoBiblico() { Id_Texto = 19, Descripcion = "Porque de tal manera amó Dios al mundo, que ha dado a su Hijo unigénito, para que todo aquel que en él cree, no se pierda, mas tenga vida eterna." };
            TextoBiblico Tb20 = new TextoBiblico() { Id_Texto = 20, Descripcion = "Y se cumplió la Escritura que dice: Abraham creyó a Dios, y le fue contado por justicia, y fue llamado amigo de Dios." };


            App.Database.InsertarTB(Tb1);
            App.Database.InsertarTB(Tb2);
            App.Database.InsertarTB(Tb3);
            App.Database.InsertarTB(Tb4);
            App.Database.InsertarTB(Tb5);
            App.Database.InsertarTB(Tb6);
            App.Database.InsertarTB(Tb7);
            App.Database.InsertarTB(Tb8);
            App.Database.InsertarTB(Tb9);
            App.Database.InsertarTB(Tb10);

            App.Database.InsertarTB(Tb11);
            App.Database.InsertarTB(Tb12);
            App.Database.InsertarTB(Tb13);
            App.Database.InsertarTB(Tb14);
            App.Database.InsertarTB(Tb15);
            App.Database.InsertarTB(Tb16);
            App.Database.InsertarTB(Tb17);
            App.Database.InsertarTB(Tb18);
            App.Database.InsertarTB(Tb19);
            App.Database.InsertarTB(Tb20);
            //Letras LZopa1 = new Letras() { IdLeccion = 1, Palabras =
            //    "B,I,V,I,C,T,O,R,I,A,D,R,F,V,M,C,G,J,L,B,N,M,F,E,D,S,C,E,U,A,V,E,N,F,E,R,M,E,D,A,D,S,E,N,K,E,S,E,B,W,R,B,I,A,I,T,R,G,I,W,S,R,E,G,R,E,S,O,K,R,T,E,E,R,N,A,L,D,S,U,D,T,H,U,E,L,U,W,D,B,B,P,V,I,E,C,C,E,A,E,J,A,A,U,D,I,B,L,E,A,V,N,S,S,G,E,D,R,D,I,B,E,S,H,G,D,F,L,L,S,A,L,U,I,C,I,O,N,T,O,D,G,O,C,A,E,S,P,E,R,A,N,Z,A,S,E,R,F,Y,I,T,Z,A,P,I,W,E,S,D,O,I,R,V,L,E,V,A,N,T,E,S,C,N,O,A,S,F,G,H,Y,T,S, ,R,A,A"
            //};
            //App.Database.InsertarLetras(LZopa1);

            //int i = 1;
            //while (i < 257)
            //{
            //    Letra a = new Letra() {IdLeccion = 1, Numero = i, Fijo = false, Temporal = false };
            //    App.Database.InsertarLetrasP(a);
            //    i++;
            //}
            Palabra LPalabra1 = new Palabra()
            {
                IdLeccion = 1,
                Palabras =
                "biblia,inspiracion,profetas,revelacion,salvacion,eterna,relevante,interesante,util,actual",
                Texto1 = @"Después de entender lo maravillosa y única que es laBiblia, Dios espera que:
1.La lea diariamente(Deuteronomio 17: 19).
2.Me convierta en un investigador de las verdades que ella contiene(Juan 5: 39).
3.Sus orientaciones sean de gozo para mí (Jeremías 15: 16).
4.Viva lo que ella enseña(Apocalipsis 1: 3).",
                Texto2 = "Busca estas palabras: Biblia, inspiración, profetas, revelación, salvación, eterna, relevante, interesante, útil, actual.",
            };
            Palabra LPalabra2 = new Palabra()
            {
                IdLeccion = 2,
                Palabras =
                "regreso,visible,audible,estruendo,esperanza,gloria,angeles,enfermedad,muerte,victoria",
                Texto1 = @"Después de entender lo maravillosa y única que es la Biblia, Dios espera que:
1. La lea diariamente (Deuteronomio 17: 19).
2. Me convierta en un investigador de las verdades que ella contiene (Juan 5: 39).
3. Sus orientaciones sean de gozo para mí (Jeremías 15: 16).
4. Viva lo que ella enseña (Apocalipsis 1: 3).",
                Texto2 = "Busca estas palabras: regreso, visible, audible, estruendo, esperanza, gloria, ángeles, enfermedad, muerte, victoria.",
            };
            Palabra LPalabra3 = new Palabra()
            {
                IdLeccion = 3,
                Palabras =
                "santuario,purificacion,perdon,ejemplo,sangre,mediacion,sacerdote,pecado,cielo,sustituto",
                Texto1 = @"Al comprender que existe un santuario en el cielo donde Jesús intercede por mis pecados, debería:
1. Acercarme al trono de la gracia de Dios para alcanzar socorro (Hebreos 4: 16).
2. Tener a Jesús como mi abogado intercesor (1 Juan 2: 1).
3. Saber que cuando estoy con Jesús no hay condenación (Romanos 8: 1).",
                Texto2 = "Busca las siguientes palabras: santuario, purificación, perdón, ejemplo, sangre, mediación, sacerdote, pecado, cielo, sustituto.",
            };
            Palabra LPalabra4 = new Palabra()
            {
                IdLeccion = 4,
                Palabras =
                "salvacion,pago,redencion,perdicion,vida,restauracion,fe,libertad,deuda,gracia",
                Texto1 = @"Después de saber que soy pecador y que Cristo murió por todos mis pecados para que tenga salvación, Dios espera:
1. Que me arrepientas de verdad (Hechos 3: 19).
2. Que confiese mis pecados a él (Juan 1: 9).
3. Que experimente una vida nueva (Ezequiel 36: 25-27).",
                Texto2 = "Busque las siguientes palabras: salvación, pago, redención, perdición, vida, restauración, fe, libertad, deuda, gracia.",
            };
            Palabra LPalabra5 = new Palabra()
            {
                IdLeccion = 5,
                Palabras =
                "batalla,satanas,conflicto,mente,tierra,orgullo,engaño,maldicion,prueba,lucha",
                Texto1 = @"Al comprender que existe un santuario en el cielo donde Jesús intercede por mis pecados, debería:
1. Acercarme al trono de la gracia de Dios para alcanzar socorro (Hebreos 4: 16).
2. Tener a Jesús como mi abogado intercesor (1 Juan 2: 1).
3. Saber que cuando estoy con Jesús no hay condenación (Romanos 8: 1).",
                Texto2 = "Busca las siguientes palabras: batalla, Satanás, conflicto, mente, tierra, orgullo, engaño, maldición, prueba, lucha.",
            };
            Palabra LPalabra6 = new Palabra()
            {
                IdLeccion = 6,
                Palabras =
                "sabado,santo,apartado,bendecido,eterna,ley,vigente,cielo,descanso,refugio",
                Texto1 = @"Después de entender que la ley de Dios sigue vigente para nosotros, incluyendo la observancia del sábado, nuestro Salvador espera que:
1. Demuestre mi amor por medio de la obediencia (Juan 14: 15).
2. Guarde los mandamientos (Salmo 119: 44).
3. Que tenga cuidado para no deshonrar el sábado (Isaías 56: 2).
4. Obedezca la orientación de Dios antes que la de los hombres (Hechos 5: 29).",
                Texto2 = "Busca las siguientes palabras: sábado, santo, apartado, bendecido, eterna, ley, vigente, cielo, descanso, refugio.",
            };
            Palabra LPalabra7 = new Palabra()
            {
                IdLeccion = 7,
                Palabras =
                "resurreccion,mortalidad,inmortalidad,vida,muerte,demonios,esperanza,transformacion,regreso,eternidad",
                Texto1 = @"La Biblia nos muestra la realidad de aquellos que mueren y la esperanza de resurrección que tenemos en Jesús, y por eso Dios espera que:
1. Crea en Jesús (Juan 11: 25).
2. Persevere en Jesús hasta alcanzar la inmortalidad que Dios dará (Romanos 2: 7).",
                Texto2 = "Busca las siguientes palabras: resurrección, mortalidad, inmortalidad, vida, muerte, demonios, esperanza, transformación, regreso, eternidad.",
            };
            Palabra LPalabra8 = new Palabra()
            {
                IdLeccion = 8,
                Palabras =
                "dones,predicacion,sanidad,hospedar,amor,profecia,elena,perfeccion,servicio,crecimiento",
                Texto1 = @"Después de saber que soy pecador y que Cristo murió por todos mis pecados para que tenga salvación, Dios espera:
1. Seamos bautizados para recibir el don del Espíritu Santo (Hechos 2: 38).
2. Que todo cuanto hagamos sea hecho para su gloria (1 Corintios 10: 31).",
                Texto2 = "Busca las siguientes palabras: dones, predicación, sanidad, hospedar, amor, profecía, Elena, perfección, servicio, crecimiento.",
            };
            App.Database.InsertarPalabras(LPalabra1);
            App.Database.InsertarPalabras(LPalabra2);
            App.Database.InsertarPalabras(LPalabra3);
            App.Database.InsertarPalabras(LPalabra4);
            App.Database.InsertarPalabras(LPalabra5);
            App.Database.InsertarPalabras(LPalabra6);
            App.Database.InsertarPalabras(LPalabra7);
            App.Database.InsertarPalabras(LPalabra8);
            //fin agregar datos estaticos
        }
        async void OnTapFiltros(object sender, EventArgs args)
        {
            var _Correo = tbCorreo.Text;
            var _Password = tbPass.Text;
            if (_Correo == "" || _Password == "" || (_Correo == "" && _Password == ""))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("Todos los campos son obligatorios!", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Todos los campos son obligatorios!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            if (String.IsNullOrWhiteSpace(_Correo))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("El campo del correo electronico es obligatorio.", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            else
            {
                //Valida que el formato del correo sea valido
                bool isEmail = Regex.IsMatch(_Correo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            Acr.UserDialogs.UserDialogs.Instance.Toast("El formato del correo electrónico es incorrecto, intente de nuevo.", new TimeSpan(0, 0, 5));

                        }
                        catch (Exception ex)
                        {
                            //Debug.WriteLine(ex.ToString());
                        }
                    });
                    return;
                }
            }

            if (String.IsNullOrWhiteSpace(_Password))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("El campo contrasena es obligatoria.", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }


            var usuario = await App.Database.LoguearUsuario(_Correo, _Password);
            if (usuario)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("Ha sido resgistrado correctamente!", new TimeSpan(0, 0, 5));
                        //Acr.UserDialogs.UserDialogs.Instance.Alert("Ha sido resgistrado correctamente!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                //_Nombre = "";
                _Correo = "";
                _Password = "";


                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;


                if (Configurations.EsPrimeraVez == "Si")
                {
                    App.NavigationService.NavigateTo("WPrimerCurso", "", historyBehavior);
                }
                else
                {
                    App.NavigationService.NavigateTo("WMisCursos", "", historyBehavior);
                }
            }
        }
        async void OnTapForgot(object sender, EventArgs args)
        {
            try
            {
                //PopupNavigation.Instance.PushAsync(new View.PopupFiltroEventos());
            }
            catch (Exception ex)
            {

            }
        }
        async void OnTapRegistro(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = true
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WRegistro", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var _Correo = tbCorreo.Text;
            var _Password = tbPass.Text;
            if (_Correo == "" || _Password == "" || (_Correo == "" && _Password == ""))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("Todos los campos son obligatorios!", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Todos los campos son obligatorios!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            if (String.IsNullOrWhiteSpace(_Correo))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("El campo del correo electronico es obligatorio.", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            else
            {
                //Valida que el formato del correo sea valido
                bool isEmail = Regex.IsMatch(_Correo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            Acr.UserDialogs.UserDialogs.Instance.Toast("El formato del correo electrónico es incorrecto, intente de nuevo.", new TimeSpan(0, 0, 5));

                        }
                        catch (Exception ex)
                        {
                            //Debug.WriteLine(ex.ToString());
                        }
                    });
                    return;
                }
            }

            if (String.IsNullOrWhiteSpace(_Password))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("El campo contrasena es obligatoria.", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }


            var usuario = await App.Database.LoguearUsuario(_Correo, _Password);
            if (usuario)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("Ha sido resgistrado correctamente!", new TimeSpan(0, 0, 5));
                        //Acr.UserDialogs.UserDialogs.Instance.Alert("Ha sido resgistrado correctamente!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                //_Nombre = "";
                _Correo = "";
                _Password = "";


                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;


                if (Configurations.EsPrimeraVez == "Si")
                {
                    App.NavigationService.NavigateTo("WPrimerCurso", "", historyBehavior);
                }
                else
                {
                    App.NavigationService.NavigateTo("WMisCursos", "", historyBehavior);
                }
            }            
        }

        void btnregistro_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var historyBehavior = true
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WRegistro", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
