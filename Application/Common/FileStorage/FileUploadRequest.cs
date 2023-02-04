namespace Application.Common.FileStorage;

public class FileUploadRequest
{
    public string Name { get; set; } = default!;
    public string Extension { get; set; } = default!;
    public string Data { get; set; } = default!;
}

public class FileUploadRequestValidator : CustomValidator<FileUploadRequest>
{
    public FileUploadRequestValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
                .WithMessage(string.Format("Image Name cannot be empty!"))
            .MaximumLength(150);

        RuleFor(p => p.Extension)
            .NotEmpty()
                .WithMessage(string.Format("Image Extension cannot be empty!"))
            .MaximumLength(5);

        RuleFor(p => p.Data)
            .NotEmpty()
                .WithMessage(string.Format("Image Data cannot be empty!"));
    }
}