(async () => {
    const entidades = await import('./entidades.js');
    const persistencia = await import('./persistencia.js');
    //let cofre = new entidades.Cofrinho();
    //cofre.adicionar(new entidades.Moeda(1, 'Um Real'));
    //cofre.adicionar(new entidades.Moeda(0.5, '50 centavos'));
    //cofre.adicionar(new entidades.Moeda(0.25, '25 centavos'));
    try {
        //await persistencia.salvarCofrinhoAsync(cofre, 'cofre.json');
        let cofre = await persistencia.lerCofrinhoAsync('cofre.json');
        console.log(cofre);
        console.log(cofre.calcularTotal());
    } catch (error) {
        console.log('Falha de processamento');
        console.log(error);
    }
})();
export {};