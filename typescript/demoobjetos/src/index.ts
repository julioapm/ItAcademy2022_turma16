class Ponto {
    x = 0;
    y = 0;
}
class Pontao {
    x = 1;
    y = 1;
}
interface UmPonto {
    readonly x: number;
    readonly y: number;
} 
const p: Ponto = new Pontao();
p.x = 10;
const p2: UmPonto = new Ponto();
p2.x = 10;
console.log(p);

class Pessoa {
    nome: string = '';
    idade: number = 0;
}
class Empregado {
    nome: string = '';
    idade: number = 0;
    salario: number = 0;
}
const alguem: Pessoa = new Empregado();
console.log(alguem);

