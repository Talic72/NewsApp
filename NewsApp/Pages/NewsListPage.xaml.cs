using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    List<Article> articleList = new();

    public NewsListPage(string categoryName)
    {
        InitializeComponent();

        Title = categoryName;

        GetNews(categoryName);
    }

    private async void GetNews(string categoryName)
    {
        var apiService = new ApiService();

        var result = await apiService.GetNews(categoryName);

        articleList = result.Articles;

        CvNews.ItemsSource = articleList;
    }

    private async void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var article = (Article)e.CurrentSelection[0];

        await Navigation.PushAsync(new NewsDetailPage(article));

        CvNews.SelectedItem = null;
    }
}