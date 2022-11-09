﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Thoughts.Domain.Base.Entities;

namespace Thoughts.Interfaces
{
    public interface IShortUrlManager
    {
        /// <summary>
        /// Получить оригинальный Url по псевдониму
        /// </summary>
        /// <param name="Alias">Псевдоним ссылки</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Оригинальный Url</returns>
        Task<Uri?> GetUrlAsync(string Alias, CancellationToken Cancel = default);

        /// <summary>
        /// Получить оригинальный Url по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор короткой ссылки</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Оригинальный Url</returns>
        Task<Uri?> GetUrlByIdAsync(int Id, CancellationToken Cancel = default);

        /// <summary>
        /// Получить псевдоним короткой ссылки по ее идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор короткой ссылки</param>
        /// <param name="Length">Количество символов в возвращаемом псевдониме</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Псевдоним ссылки</returns>
        Task<string> GetAliasByIdAsync(int Id, int Length = 0, CancellationToken Cancel = default);

        /// <summary>
        /// Добавить короткую ссылку
        /// </summary>
        /// <param name="Url">Добавляемый Url</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Идентификатор добавленной короткой ссылки</returns>
        Task<int> AddUrlAsync(string Url, CancellationToken Cancel = default);

        /// <summary>
        /// Удалить короткую ссылку по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор короткой ссылки</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Результат удаления</returns>
        Task<bool> DeleteUrlAsync(int Id, CancellationToken Cancel = default);

        /// <summary>
        /// Обновить короткую ссылку
        /// </summary>
        /// <param name="Id">Идентификатор короткой ссылки</param>
        /// <param name="Url">Новый Url</param>
        /// <param name="Cancel">Токен отмены</param>
        /// <returns>Результат обновления</returns>
        Task<bool> UpdateUrlAsync(int Id, string Url, CancellationToken Cancel = default);

        /// <summary>
        /// Сброс статистики использования коротких ссылок
        /// </summary>
        /// <param name="Id">Идентификатор короткой ссылки для которой сбрасывается статистика. 
        /// Если идентификатор 0, то статистика сбрасывается для всех ссылок</param>
        /// <returns>Результат сброса статистики</returns>
        Task<bool> ResetStatistic(int Id = 0, CancellationToken Cancel = default);

        /// <summary>
        /// Получение статистики использования коротких ссылок
        /// </summary>
        /// <param name="Id">Идентификатор короткой ссылки для которой запрашивается статистика. 
        /// Если идентификатор 0, то статистика запрашивается для всех ссылок</param>
        /// <returns>Перечисление коротких ссылок</returns>
        Task<IEnumerable<ShortUrl>> GetStatistic(int Id = 0, int Length = 0, CancellationToken Cancel = default);
    }
}