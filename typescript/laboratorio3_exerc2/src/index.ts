class Moeda {
    constructor(
        private _valor: number,
        private _nome: string
    ){}
    get valor() {
        return this._valor;
    }
    get nome() {
        return this._nome;
    }
}

class Cofrinho {
    private _moedas: Moeda[] = [];
    adicionar(m: Moeda) {
        this._moedas.push(m);
    }
    calcularTotal() {
        return this._moedas
            .map(m => m.valor)
            .reduce((somatorio,valor) => somatorio + valor);
    }
}

let cofre = new Cofrinho();
cofre.adicionar(new Moeda(1, 'Um Real'));
cofre.adicionar(new Moeda(0.5, '50 centavos'));
cofre.adicionar(new Moeda(0.25, '25 centavos'));
console.log(cofre.calcularTotal());