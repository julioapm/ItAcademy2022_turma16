abstract class Cliente {
    constructor(
        private _nome: string
    ){}
    get nome() {
        return this._nome;
    }
    abstract get mensalidade(): number;
    toString() {
        return `Nome: ${this.nome}, Mensalidade: ${this.mensalidade}`;
    }
}

class ClienteFisico extends Cliente {
    constructor(
        nome: string,
        public idade: number,
        public salario: number
    ){
        super(nome);
    }
    get mensalidade(): number {
        if (this.idade < 60) {
            return this.salario * 0.1;
        } else {
            return this.salario * 0.15;
        }
    }
}

const c = new ClienteFisico('João', 20, 1000);
console.log(c.toString());
console.log(c.idade);
console.log(c.mensalidade);
const c2: Cliente = new ClienteFisico('Maria', 30, 2000);
console.log(c2.toString());
//console.log(c2.idade);
console.log(c2.mensalidade);