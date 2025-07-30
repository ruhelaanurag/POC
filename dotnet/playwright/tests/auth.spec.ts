import { test, expect } from '@playwright/test';
import path from 'path';

const authFile = path.join(__dirname, '../playwright/.auth/user.json');

test('test', async ({ page, browser }) => {
  await page.goto('https://ogt-gtm-web-reg.8443.aws-int.thomsonreuters.com/Logon.aspx');
  await page.getByPlaceholder('Company').click();
  await page.getByPlaceholder('Company').fill('fta');
  await page.getByPlaceholder('Company').press('Tab');
  await page.getByPlaceholder('User Name').fill('aruhela1');
  await page.getByPlaceholder('User Name').press('Tab');
  await page.getByPlaceholder('Password').fill('TGByhn!@55');
  await page.getByRole('link', { name: 'Login' }).click();
  //await page.goto('https://ogt-gtm-web-qa.8443.aws-int.thomsonreuters.com/gtm/home');
  //page.waitForResponse("domcontentloaded",{timeout: 50000});
  await expect(page).toHaveTitle('ONESOURCE Global Trade');

  await page.context().storageState({ path: authFile });

  // // //await page.goto('https://ogt-gtm-web-qa.8443.aws-int.thomsonreuters.com/gtm/home');

  // //   await page.getByRole('button', { name: 'Anurag Ruhela ' }).click();
  // //   await page.getByText('Version:24.4').click();
  // //   await page.locator('body').press('Escape');
  // //   await page.getByRole('button', { name: 'Reg FTA (2032) ' }).click();
    //await page.getByPlaceholder('Search by name or partner id').press('Escape');

  // await browser.contexts().forEach(async context => {
  //   await context.storageState({ path: authFile });
});