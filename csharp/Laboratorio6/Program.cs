List<Conta> contas = new List<Conta>();
contas.Add(new ContaCorrente("Júlio"));
contas.ForEach(c => Console.WriteLine(c.Id));
