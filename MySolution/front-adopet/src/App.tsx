import React, { useEffect, useState } from 'react';
import './styles/index.css';
import axios from 'axios';
import AbrigosList from './components/AbrigosList';
import AdocaoForm from './components/AdocaoForm';
import AnimalCard from './components/AnimalCard';

interface Animal {
    AnimalId: number;
    Nome: string;
    Especie: string;
    Raca: string;
    Idade: number;
    DisponivelParaAdocao: boolean;
}

const App: React.FC = () => {
    const [animais, setAnimais] = useState<Animal[]>([]);

    useEffect(() => {
        axios.get('http://localhost:5286/adopet/animais/listar')
            .then(response => setAnimais(response.data))
            .catch(error => console.error('Erro ao buscar animais:', error));
    }, []);

    return (
        <div className="container">
            <h1>Bem-vindo ao Adopet</h1>
            <AdocaoForm />
            <div className="animal-list">
                {animais.map(animal => (
                    <AnimalCard key={animal.AnimalId} animal={animal} />
                ))}
            </div>
            <AbrigosList />
        </div>
    );
};

export default App;
