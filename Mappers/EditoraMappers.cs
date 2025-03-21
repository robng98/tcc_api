using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Editora; // Add this line to include the namespace for EditoraDto
using tcc1_api.Models; // Add this line to include the namespace for Editora

namespace tcc1_api.Mappers
{
    public static class EditoraMappers
    {
        public static EditoraDto ToEditoraDto(this Editora editora)
        {
            return new EditoraDto
            {
                Id = editora.Id,
                AnoCriacao = editora.AnoCriacao,
                Nome = editora.Nome,
                Logo = editora.Logo,
                TotalSeries = editora.Series.Count
            };
        }

        public static Editora ToEditoraFromCreateEditoraDTO(this CreateEditoraRequestDto editoraDto)
        {
            return new Editora
            {
                AnoCriacao = editoraDto.AnoCriacao,
                Nome = editoraDto.Nome,
                Logo = editoraDto.Logo
            };
        }

        public static Editora ToEditoraFromUpdateEditoraDTO(this UpdateEditoraRequestDto editoraDto)
        {
            return new Editora
            {
                AnoCriacao = editoraDto.AnoCriacao,
                Nome = editoraDto.Nome,
                Logo = editoraDto.Logo
            };
        }
    }
}