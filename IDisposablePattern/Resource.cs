using System;
using System.Collections.Generic;
using System.Text;

namespace IDisposablePattern
{
    //Шаблон Microsoft для освобождения ресурсов. -
    //Данный паттерн гаратирует, что ползовател, сможет многократно вызывать метод Dispose() [многократно - tekrar ]


    class Resource : IDisposable
    //Реализация интерфейса с шаблоном IDisposable
    //Implement Interface with IDisposable Pattern

    {
        //IDisposable Support

        //Флаг показывающий вызов метода Dispose()
        private bool disposed = false; // To detect redundant calls
                                       //Dispose поможет нам освободить объект только один раз.
       // Просто мы будем проверять этот dispose и зависимости от его.
        //И будем понимать что мы ранше освобождали  етоть обккт или не освобождали.

        public void Dispose()
        {
            //Вызов вспомогательно метода.
            //Если true, значит очистку иницировал  пользователь обйекта

            //true в Metode CleanUp(true) обозначаеть что очиска у  нас иничилиована 
            //метода Dispose а не  Деструкторам.

            CleanUp(true);

            //SuppressFinalize()- устанавливает флаг запрешения завершения для обьектов
            //которые в противном случае могли бы быть завершены сборщиком мусора.
            //отменяет работу деструктора для данного класса

            // Он устанавливает специальный флаг который запрещать выполнение финализатора 
            //и отработку Деструктора для данного ласса
            
            GC.SuppressFinalize(this);
        }
        //Сборщик мусора вызывает Деструктор, если пользователь объекта забудет вызвать метод Dispose();

        ~Resource()
        { 
            Console.WriteLine("Finalise!!!!!!!!!!!");
            CleanUp(false);
            // Eto znacit cto u nas Metod Cleanup- Metod ocistki  bil vizvan Destruktoram a ne Dispose()
        }

        //Метод для избежания дублирования кода в Деструктора и методе Dispose()

        private void CleanUp(bool clean)
        {
            //Проверка, что ресурсу еще не освобождены.
            if (!this.disposed)//Esli obyekt ne vizvalsya 
            {
                if (clean)
                {
                   // Внутри этого цикла мы выполняем оиску управляемых ресурсов
                   // Здесь будет код который  отвечаеть очистку за управляемых  ресурсов
                    //Если clean равно true, освободить се управляемые ресурсы.

                    Console.WriteLine("Освобождение ресурсов");
                    Cars cars = new Cars();
                    cars.GetCars();
                }
                Console.WriteLine("Finalized");
               //Здес будет блог для очистки не управляемых ресурсов что ето знаить?
               //Здес будет особждаться файлы ,  подключение socket, какие те подключение
            }
            this.disposed = true;
            //Это значить что объект был освобожден
        }
        //С помошу все етого  мы запрешаем  уборшичу мусору взывать finalizator CleanUp(false)
        //Что бы finalizator не отрабатывал при удаление объекта, он еще раз не выполнл очистку CleanUp();

        //Если мы забыли вызвать метод Dispose()  
        //То тогда у нас при удаление обйекта вызываеться ~REsourceWrapper
        //И он выполняет очистку толко Не Управлемых ресурсов.
     
    }

}

