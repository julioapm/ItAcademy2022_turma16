const vazio = {};
console.log(typeof vazio);

const umaPessoa = {
    nome: 'John Doe',
    idade: 20,
    toString: function() {
        return `Nome=${this.nome}, Idade=${this.idade}`
    }
};
console.log(umaPessoa.nome);
console.log(umaPessoa.toString());

function alo(pessoa: {nome: string, idade: number}) {
    return `Alo ${pessoa.nome}`;
}
console.log(alo(umaPessoa));

let {nome:umNome,idade} = umaPessoa;
console.log(umNome);
console.log(idade);

interface Pessoa {
    nome: string;
    idade: number;
    toString(): string
}

function aloInterface(pessoa: Pessoa) {
    return `Alo ${pessoa.nome}`;
}
console.log(aloInterface(umaPessoa));

console.log(Object.getPrototypeOf(umaPessoa));