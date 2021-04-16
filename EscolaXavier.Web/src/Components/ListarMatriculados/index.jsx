import React, { useEffect, useState } from "react";
import styled from "styled-components";
import api from "../../services/api";
import {
  Botao,
  Box,
  Formulario,
  Titulo,
  Select,
  Input,
} from "../../UI/GlobalStyle";

const ListarMatriculados = () => {
  const [matriculasDto, setMatriculasDto] = useState([]);

  useEffect(async () => {
    let retorno = await api.get("Matricula/ObterTodos");

    retorno.data.dados.forEach(async (element) => {
      let retornoNomeAluno = await api.get(
        "aluno/ObterPorId?id=" + element.alunoId
      );
      let retornoNomeMateria = await api.get(
        "materia/ObterPorId?id=" + element.materiaId
      );

      let matricula = {
        id: element.id,
        nomeAluno: retornoNomeAluno.data.dados.nomeAluno,
        nomeMateria: retornoNomeMateria.data.dados.nomeMateria,
        nota: element.nota,
      };

      matriculasDto.push(matricula);
    });
    setMatriculasDto(matriculasDto);
  }, []);

  return (
    <Box>
      <table>
        <thead>
          <tr>
            <th>Nome</th>
            <th>Matéria</th>
            <th>Nota</th>
            <th>Situação</th>
          </tr>
        </thead>
        <tbody>
          {matriculasDto.map((item, index) => {
            return (
              <tr key={index}>
                <td>{item.nomeAluno}</td>
                <td>{item.nomeMateria}</td>
                <td>{item.nota}</td>
                <td>{item.nota >= 7 ? "Aprovado" : "Reprovado"}</td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </Box>
  );
};

export default ListarMatriculados;
