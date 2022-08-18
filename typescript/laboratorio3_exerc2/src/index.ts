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
        
    }
}