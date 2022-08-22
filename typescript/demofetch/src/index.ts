import fetch from 'node-fetch';
import { Post } from './post.js';

async function main() {
    const uriBase = 'https://jsonplaceholder.typicode.com';
    try {
        //Realizar um GET
        const resposta = await fetch(`${uriBase}/posts`);
        if (resposta.ok) {
            const dadosJson = await resposta.json() as Post[];
            console.log('Dados:');
            console.log(dadosJson[0].title);
        } else {
            console.log('GET status:', resposta.status);
            console.log('GET statusText:', resposta.statusText);
        }
    } catch (error) {
        console.log('Falha na requisição HTTP');
        console.log(error);
    }
}

main();