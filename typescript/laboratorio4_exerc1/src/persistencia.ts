import { Cofrinho, Moeda } from './entidades.js';
import * as fs from 'node:fs/promises';

async function salvarCofrinhoAsync(cofrinho: Cofrinho, nomeArquivo: string) {
    const json = JSON.stringify(cofrinho);
    return fs.writeFile(nomeArquivo, json);
}

async function lerCofrinhoAsync(nomeArquivo: string) {
    const json = await fs.readFile(nomeArquivo, 'utf-8');
    const cofrinho = JSON.parse(json) as Cofrinho;
    return cofrinho;
}

export {salvarCofrinhoAsync, lerCofrinhoAsync};
