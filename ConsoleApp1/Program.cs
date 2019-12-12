using InstantFun.Domain.BindingModels;
using ServiceStack.Redis;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            M2();
        }

        static void M1()
        {
            var registerBindingModel = new RegisterBindingModel { Email = "gabrielzxc2@gmail.com4", Password = "teste4", PhoneNumber = "11958395433", UserName = "gabrielmotakiru" };
            var key = $"[{registerBindingModel.Email}-{registerBindingModel.Password}-{registerBindingModel.PhoneNumber}-{registerBindingModel.UserName}]";
            var date = DateTime.Now;

            try
            {
                for (var count = 0; count < 100; count++)
                {
                    date = DateTime.Now;
                    //using (var redisClient = new RedisClient("redis-13893.c8.us-east-1-3.ec2.cloud.redislabs.com", 13893, "R6BdMdvUEK6rHEGJVgGdF92dli3gkSUH"))
                    using (var redisClient = new RedisClient("localhost:6379"))
                    {
                        if (redisClient.Exists((key + count).ToString()) > 0)
                        {
                            Console.WriteLine($"Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        }
                        else
                        {
                            redisClient.Set<RegisterBindingModel>((key + count).ToString(), registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                            Console.WriteLine($"Chave adicionada. Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        }

                        if (redisClient.Exists(key) > 0)
                        {
                            Console.WriteLine($"Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        }
                        else
                        {
                            redisClient.Set<RegisterBindingModel>(key, registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                            Console.WriteLine($"Chave adicionada. Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
            }
        }

        static void M3()
        {
            var registerBindingModel = new RegisterBindingModel { Email = "gabrielzxc2@gmail.com4", Password = "teste4", PhoneNumber = "11958395433", UserName = "gabrielmotakiru" };
            var key = $"[{registerBindingModel.Email}-{registerBindingModel.Password}-{registerBindingModel.PhoneNumber}-{registerBindingModel.UserName}]";
            var date = DateTime.Now;

            try
            {
                date = DateTime.Now;
                Console.WriteLine($"Inicio 1 - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");

                using (var redisClient = new RedisClient("localhost:6379"))
                {
                    if (redisClient.Exists("1000") > 0)
                    {
                        date = DateTime.Now;
                        Console.WriteLine($"Existe chave 1 - Chave: 1000 já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    }
                    else
                    {
                        date = DateTime.Now;
                        Console.WriteLine($"Cria chave 1 - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        redisClient.Set<RegisterBindingModel>("1000", registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                        date = DateTime.Now;
                        Console.WriteLine($"Adicionada chave 1 - Chave adicionada. Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    }

                    date = DateTime.Now;
                    Console.WriteLine($"Inicio 2 - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");

                    if (redisClient.Exists("1000") > 0)
                    {
                        date = DateTime.Now;
                        Console.WriteLine($"Existe chave 2 - Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    }
                    else
                    {
                        date = DateTime.Now;
                        Console.WriteLine($"Cria chave 2 - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        redisClient.Set<RegisterBindingModel>(key, registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                        date = DateTime.Now;
                        Console.WriteLine($"Adicionada chave 2 - Chave adicionada. Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
            }
        }

        static void M2()
        {
            var registerBindingModel = new RegisterBindingModel { Email = "gabrielzxc2@gmail.com4", Password = "teste4", PhoneNumber = "11958395433", UserName = "gabrielmotakiru" };
            var key = $"[{registerBindingModel.Email}-{registerBindingModel.Password}-{registerBindingModel.PhoneNumber}-{registerBindingModel.UserName}]";
            var date = DateTime.Now;

            try
            {
                using (var redisClient = new RedisClient("localhost:6379"))
                {
                    date = DateTime.Now;
                    Console.WriteLine($"Cria chave 1 - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    redisClient.Set<RegisterBindingModel>("1000", registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                    
                    date = DateTime.Now;
                    Console.WriteLine($"Verificação de Exists() - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");

                    if (redisClient.Exists("1000") > 0)
                    {
                        date = DateTime.Now;
                        Console.WriteLine($"Existe chave 2 - Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    }
                    else
                    {
                        date = DateTime.Now;
                        Console.WriteLine($"Cria chave 2 - Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                        redisClient.Set<RegisterBindingModel>(key, registerBindingModel, new TimeSpan(0, 0, 0, 60, 0));
                        date = DateTime.Now;
                        Console.WriteLine($"Adicionada chave 2 - Chave adicionada. Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Chave já existe: Data: {date.ToLongDateString()} - Hora: {date.ToLongTimeString()} - Milisegundo: {date.Millisecond}");
            }
        }
    }
}
