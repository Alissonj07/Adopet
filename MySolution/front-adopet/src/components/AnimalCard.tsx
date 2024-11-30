import React from 'react';

interface Animal {
    AnimalId: number;
    Nome: string;
    Especie: string;
    Raca: string;
    Idade: number;
    DisponivelParaAdocao: boolean;
}

const AnimalCard: React.FC<{ animal: Animal }> = ({ animal }) => {
    return (
        <div className="animal-card">
            <h3>{animal.Nome}</h3>
            <p>Espécie: {animal.Especie}</p>
            <p>Raça: {animal.Raca}</p>
            <p>Idade: {animal.Idade} anos</p>
            <p>Disponível para Adoção: {animal.DisponivelParaAdocao ? "Sim" : "Não"}</p>
        </div>
    );
};

export default AnimalCard;
