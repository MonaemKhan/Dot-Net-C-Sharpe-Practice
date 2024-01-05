namespace InvenTrackPro.SharedKernel.Interfaces;
public interface IEmailSender
{
    #region Methods

    /// <summary>
    /// The SendEmailAsync.
    /// </summary>
    /// <param name="email">The email<see cref="string"/>.</param>
    /// <param name="subject">The subject<see cref="string"/>.</param>
    /// <param name="message">The message<see cref="string"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    Task SendEmailAsync(string email, string subject, string message);

    #endregion
}
