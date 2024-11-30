import React, { useState } from 'react';
import api from '../services/api';
import '../styles/index.css';

interface Adocao {
    AdotanteId: string;
    AnimalId: string;
    Status: 'Pendente' | 'Aprovada' | 'Rejeitada'; // Especifique os valores possíveis da enumeração
}

const AdocaoForm: React.FC = () => {
    const [adocao, setAdocao] = useState<Adocao>({
        AdotanteId: '',
        AnimalId: '',
        Status: 'Pendente'
    });
    const [loading, setLoading] = useState(false);
    const [mensagem, setMensagem] = useState<string | null>(null);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setAdocao({ ...adocao, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setMensagem(null);
        try {
            const response = await api.post('/adocoes/cadastrar', adocao);
            setMensagem('Adoção registrada com sucesso!');
            setAdocao({ AdotanteId: '', AnimalId: '', Status: 'Pendente' });
            console.log('Adoção registrada com sucesso:', response.data);
        } catch (error) {
            console.error('Erro ao registrar adoção:', error);
            setMensagem('Erro ao registrar adoção. Tente novamente.');
        } finally {
            setLoading(false);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Cadastrar Adoção</h2>
            {mensagem && <p className={mensagem.includes('Erro') ? 'erro' : 'sucesso'}>{mensagem}</p>}
            <label>
                Adotante ID:
                <input type="text" name="AdotanteId" value={adocao.AdotanteId} onChange={handleChange} />
            </label>
            <label>
                Animal ID:
                <input type="text" name="AnimalId" value={adocao.AnimalId} onChange={handleChange} />
            </label>
            <label>
                Status:
                <select name="Status" value={adocao.Status} onChange={handleChange} className="custom-select">
                    <option value="Pendente">Pendente</option>
                    <option value="Aprovada">Aprovada</option>
                    <option value="Rejeitada">Rejeitada</option>
                </select>
            </label>
            <button type="submit" disabled={loading}>
                {loading ? 'Cadastrando...' : 'Cadastrar'}
            </button>
        </form>
    );
};

export default AdocaoForm;
