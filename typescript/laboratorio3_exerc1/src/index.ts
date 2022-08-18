/*
class Circulo {
    raio: number = 1;
    pontox: number = 0;
    pontoy: number = 0;
}
const circ = new Circulo();
console.log(circ.raio);
*/

/*
class Circulo {
    raio: number;
    pontox: number;
    pontoy: number;
    constructor(r: number = 1, x: number = 0, y: number = 0) {
        this.raio = r;
        this.pontox = x;
        this.pontoy = y;
    }
}
const circ = new Circulo(3,1,1);
console.log(circ.raio);
const circ2 = new Circulo();
console.log(circ2.raio);
*/
/*
class Circulo {
    constructor(
        public raio: number = 1,
        public pontox: number = 0,
        public pontoy: number = 0
    ){}
}
const circ = new Circulo(3,1,1);
console.log(circ.raio);
const circ2 = new Circulo();
console.log(circ2.raio);
*/
class Circulo {
    constructor(
        private _raio: number = 1,
        private _pontox: number = 0,
        private _pontoy: number = 0
    ){}
    
    get raio() {
        return this._raio;
    }
    
    set raio(r) {
        this._raio = r;
    }

    area() {
        return Math.PI * this._raio * this._raio;
    }

    circunferencia() {
        return 2 * Math.PI * this._raio;
    }
}
const circ = new Circulo(3,1,1);
console.log(circ.raio);
const circ2 = new Circulo();
console.log(circ2.raio);
circ2.raio = 10;
console.log(circ2.area());
console.log(circ2.circunferencia());
