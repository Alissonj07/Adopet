import React, { useEffect, useState } from 'react';
import api from '../services/api';

interface Abrigo {
    AbrigoId: number;
    Nome: string;
}

const AbrigosList: React.FC = () => {
    const [abrigos, setAbrigos] = useState<Abrigo[]>([]);
    const [erro, setErro] = useState<string | null>(null);
    const [carregando, setCarregando] = useState<boolean>(true);

    const fetchAbrigos = async () => {
        try {
            setCarregando(true);
            const response = await api.get<Abrigo[]>('/abrigos/listar');
            setAbrigos(response.data);
            setErro(null);
        } catch (error: any) {
            console.error('Erro ao buscar abrigos:', error);
            setErro(
                error.response?.status === 404
                    ? 'Nenhum abrigo encontrado.'
                    : 'Erro ao buscar os abrigos, tente novamente.'
            );
        } finally {
            setCarregando(false);
        }
    };

    useEffect(() => {
        fetchAbrigos();
    }, []);

    if (carregando) return <p>Carregando abrigos...</p>;

    return (
        <div>
            <h2>Lista de Abrigos</h2>
            {erro ? (
                <p style={{ color: 'red' }}>{erro}</p>
            ) : (
                <ul>
                    {abrigos.length > 0 ? (
                        abrigos.map(abrigo => (
                            <li key={abrigo.AbrigoId}>{abrigo.Nome}</li>
                        ))
                    ) : (
                        <p>Nenhum abrigo disponível no momento.</p>
                    )}
                </ul>
            )}
        </div>
    );
};

export default AbrigosList;
