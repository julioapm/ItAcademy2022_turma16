ContaCorrente conta1 = new ContaCorrente(0);
ContaCorrente conta2 = new ContaCorrente(1);
conta1.Depositar(100);
conta1.Sacar(50);
Console.WriteLine(conta1.Saldo);
