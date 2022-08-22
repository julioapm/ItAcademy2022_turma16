export class Moeda {
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

export class Cofrinho {
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
